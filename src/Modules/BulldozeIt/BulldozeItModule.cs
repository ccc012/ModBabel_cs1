using HarmonyLib;

namespace ModBabel.Modules.BulldozeIt
{
    // Mod original: "Bulldoze It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1627986403
    // Código-fonte: https://github.com/keallu/CSL-BulldozeIt (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BulldozeIt"
    // - Mesmo autor do Play It!, mas aqui não tem UIPanel customizado -
    //   OnSettingsUI usa o UIHelper padrão do jogo com literais
    //   hardcoded (igual o Play It!, ver ModuleBabel.Modules.PlayIt).
    //   Como não tem campo interceptável, a solução foi pular o método
    //   original (Prefix retornando false) e remontar a mesma tela já
    //   traduzida, lendo/escrevendo BulldozeIt.ModConfig.Instance via
    //   reflection (Traverse).
    public class BulldozeItModule : Core.IModule
    {
        public string ModuloId => "bulldozeit";

        public string AssemblyDoModOriginal => "BulldozeIt";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
