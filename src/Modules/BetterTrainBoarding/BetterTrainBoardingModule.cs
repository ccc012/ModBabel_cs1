using HarmonyLib;

namespace ModBabel.Modules.BetterTrainBoarding
{
    // Mod original: "Better Train Boarding" por Vectorial1024
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2773460744
    // Código-fonte: https://github.com/Vectorial1024/BetterTrainBoarding (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BetterTrainBoarding"
    // - Mod só de patches Harmony, sem tela de opções - o único texto
    //   visível é a descrição no Content Manager (propriedade normal,
    //   não implementação explícita de interface).
    public class BetterTrainBoardingModule : Core.IModule
    {
        public string ModuloId => "bettertrainboarding";

        public string AssemblyDoModOriginal => "BetterTrainBoarding";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
