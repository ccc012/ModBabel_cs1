using System;
using System.Collections.Generic;
using System.Linq;

namespace ModBabel.Core
{
    // Detecta quais mods originais estão ativos e só liga os módulos
    // (patches) correspondentes. Um jogador sem um mod original
    // instalado simplesmente não recebe nenhum patch daquele módulo.
    public static class ModuleRegistry
    {
        // Lista manual dos módulos implementados - adicionar aqui
        // cada novo módulo criado em src/Modules/
        private static readonly List<IModule> TodosOsModulos = new List<IModule>
        {
            new Modules.Rainfall.RainfallModule(),
            new Modules.PlayIt.PlayItModule(),
            new Modules.AdvancedStopSelection.AdvancedStopSelectionModule(),
            new Modules.AutoLineBudget.AutoLineBudgetModule(),
            new Modules.BetterBudget.BetterBudgetModule(),
            new Modules.BetterEducationToolbar.BetterEducationToolbarModule(),
            new Modules.BetterHealthCareToolbar.BetterHealthCareToolbarModule(),
            new Modules.BetterTrainBoarding.BetterTrainBoardingModule(),
            new Modules.Birdcage.BirdcageModule(),
            new Modules.Breakdown.BreakdownModule(),
            new Modules.BrokenNodeDetector.BrokenNodeDetectorModule(),
            new Modules.BuildingSpawnPoints.BuildingSpawnPointsModule(),
            new Modules.BulldozeIt.BulldozeItModule(),
            new Modules.CheckRoadAccessForGrowables.CheckRoadAccessForGrowablesModule(),
            new Modules.CommuterDestination.CommuterDestinationModule(),
            // new Modules.ModuloExemplo.ModuloExemplo(), // template, não ativar
        };

        public static void AtivarModulosDisponiveis(HarmonyLib.Harmony harmony)
        {
            var assembliesCarregadas = new HashSet<string>(
                AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetName().Name));

            foreach (var modulo in TodosOsModulos)
            {
                if (!assembliesCarregadas.Contains(modulo.AssemblyDoModOriginal))
                {
                    UnityEngine.Debug.Log(
                        $"[ModBabel] Módulo '{modulo.ModuloId}' ignorado - " +
                        $"mod original '{modulo.AssemblyDoModOriginal}' não está instalado/ativo.");
                    continue;
                }

                modulo.AplicarPatches(harmony);
                UnityEngine.Debug.Log($"[ModBabel] Módulo '{modulo.ModuloId}' ativado.");
            }
        }
    }
}
