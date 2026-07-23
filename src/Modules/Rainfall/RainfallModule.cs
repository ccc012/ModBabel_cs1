using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Rainfall
{
    // Mod original: "Rainfall" por [SSU]yenyang
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=698395457
    // Código-fonte: https://github.com/yenyang/rainfall (MIT, aberto)
    //
    // Confirmado por leitura do código-fonte (2026-07-23):
    // - Sem sistema de locale próprio (o autor confirmou nos comentários
    //   do Workshop: "I never made localization for this mod")
    // - Todas as strings de UI ficam em Source/UI/OptionHandler.cs,
    //   dentro do método SetUpOptions(UIHelperBase helper) - é a tela
    //   de opções do próprio mod, não painéis espalhados pelo jogo
    // - ROTA 2 (Harmony patch) confirmada como necessária
    public class RainfallModule : IModule
    {
        public string ModuloId => "rainfall";

        // Nome do assembly do mod original - a confirmar contra a .dll
        // instalada (o .csproj do Rainfall sugere AssemblyName "Rainfall")
        public string AssemblyDoModOriginal => "Rainfall";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.SetUpOptionsPatch)).Patch();
        }
    }
}
