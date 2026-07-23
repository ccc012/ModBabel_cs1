using HarmonyLib;

namespace ModBabel.Modules.BrokenNodeDetector
{
    // Mod original: "Broken Nodes Detector" (CitiesSkylinesMods)
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1777173984
    // Código-fonte: https://github.com/CitiesSkylinesMods/BrokenNodeDetector (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BrokenNodeDetector"
    // - Mod grande, com 8 ferramentas de diagnóstico independentes
    //   (BrokenNodes, GhostNodes, DisconnectedBuildings, ShortSegments,
    //   StuckCims, etc.), cada uma com seus próprios textos hardcoded
    //   espalhados em arquivos separados ("Great! Nothing found :-)",
    //   "Preparing...", etc.). Traduzir tudo exigiria um patch por
    //   ferramenta - desproporcional pro valor nesta primeira passada
    //   (mod usado ocasionalmente, não durante o jogo normal).
    // - Nesta versão: só a descrição do Content Manager foi traduzida.
    //   PENDÊNCIA: textos das telas de cada ferramenta de diagnóstico.
    public class BrokenNodeDetectorModule : Core.IModule
    {
        public string ModuloId => "brokennodedetector";

        public string AssemblyDoModOriginal => "BrokenNodeDetector";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
