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
            new Modules.CustomEffectLoader.CustomEffectLoaderModule(),
            new Modules.EmptyIt.EmptyItModule(),
            new Modules.ExpressBusServices.ExpressBusServicesModule(),
            new Modules.ExtraTrainStationTracks.ExtraTrainStationTracksModule(),
            new Modules.EnlightenYourMouse.EnlightenYourMouseModule(),
            new Modules.FavoriteCims.FavoriteCimsModule(),
            new Modules.GravitativeCableCar.GravitativeCableCarModule(),
            new Modules.HideCrosswalksRenewed.HideCrosswalksRenewedModule(),
            new Modules.HideUnconnectedTracksRenewed.HideUnconnectedTracksRenewedModule(),
            new Modules.RealisticWinds.RealisticWindsModule(),
            // new Modules.ModuloExemplo.ModuloExemplo(), // template, não ativar
        };

        // Contadores expostos pra tela de opções mostrar algo como
        // "12 de 15 mods traduzidos detectados nesta partida" - hoje
        // isso só ficava no log, sem nenhuma indicação visível pro
        // jogador de quantos dos módulos escritos realmente se
        // aplicam à instalação dele.
        public static int TotalModulos => TodosOsModulos.Count;

        public static int ModulosAtivados { get; private set; }

        public static void AtivarModulosDisponiveis(HarmonyLib.Harmony harmony)
        {
            ModulosAtivados = 0;

            var assembliesCarregadas = new HashSet<string>(
                AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetName().Name));

            foreach (var modulo in TodosOsModulos)
            {
                if (!assembliesCarregadas.Contains(modulo.AssemblyDoModOriginal))
                {
                    Logger.Log(
                        $"Módulo '{modulo.ModuloId}' ignorado - " +
                        $"mod original '{modulo.AssemblyDoModOriginal}' não está instalado/ativo.");
                    continue;
                }

                // Cada módulo é aplicado dentro do próprio try/catch:
                // um nome de classe/campo errado (ex: código-fonte
                // público divergente do binário publicado no Workshop -
                // já aconteceu com Birdcage, TargetMethod() retornando
                // null) faz o Harmony lançar HarmonyException dentro de
                // PatchClassProcessor.Patch(). Sem isso, a exceção subia
                // até PluginManager.AddPlugins e derrubava o
                // carregamento de TODOS os mods do jogo - não só o
                // ModBabel (visto em jogo, 2026-07-24). Um módulo
                // quebrado agora só falha ele mesmo; os outros
                // continuam funcionando normalmente.
                try
                {
                    modulo.AplicarPatches(harmony);
                    ModulosAtivados++;
                    Logger.Log($"Módulo '{modulo.ModuloId}' ativado.");
                }
                catch (Exception e)
                {
                    Logger.LogErro(
                        $"Falha ao ativar o módulo '{modulo.ModuloId}' - " +
                        "esse mod específico não será traduzido, mas o restante do " +
                        $"ModBabel e dos outros mods continua funcionando normalmente. Erro: {e}");
                }
            }
        }
    }
}
