using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.CommuterDestination.Patches
{
    // SettingsUI.BuildPanel(UIHelper) monta o grupo "Integrations" com
    // um label dinâmico ("Improved Public Transport 2: Detected/Not
    // detected"). Postfix roda o walker genérico
    // (Core/UiTreeTranslator.cs) no painel já montado - cobre o título
    // do grupo e o label de uma vez. O parâmetro é o tipo real
    // ColossalFramework.UI.UIHelper (já referenciado pelo projeto), não
    // precisa de reflection pra ele.
    [HarmonyPatch]
    public static class BuildPanelPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("CommuterDestination.CS1.UI.SettingsUI"), "BuildPanel");

        [HarmonyPostfix]
        public static void Postfix(UIHelper helper)
        {
            if (helper.self is UIComponent painel)
                UiTreeTranslator.Traduzir("commuterdestination", painel);
        }
    }
}
