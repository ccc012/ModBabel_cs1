using HarmonyLib;

namespace ModBabel.Modules.BetterBudget
{
    // Mod original: "Better Budget" por unobtanium (correções por airenelias)
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=420972688
    // Código-fonte: https://github.com/un0btanium/BetterBudget (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BetterBudget"
    // - Sem sistema de tradução próprio. Monta 3 painéis customizados do
    //   zero (UICustomBudgetPanel, UICustomBudgetPanelSelector,
    //   UIEmbeddedBudgetPanelSelector - UIEmbeddedBudgetPanel não tem
    //   texto hardcoded, só reaproveita os do jogo), cada um com um
    //   método público "initialize(...)" que monta a UI - mesmo padrão
    //   do Play It!, então reaproveitamos o UiTreeTranslator genérico
    //   (ver Core/UiTreeTranslator.cs) num Postfix em cada initialize.
    public class BetterBudgetModule : Core.IModule
    {
        public string ModuloId => "betterbudget";

        public string AssemblyDoModOriginal => "BetterBudget";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.UICustomBudgetPanelPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.UICustomBudgetPanelSelectorPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.UIEmbeddedBudgetPanelSelectorPatch)).Patch();
        }
    }
}
