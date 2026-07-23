using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.PlayIt.Patches
{
    // Mesma ideia do MainPanelCreateUIPatch, aplicada ao relógio
    // flutuante (PlayIt.Panels.ClockPanel). Os textos numéricos ("11:07",
    // "0°") são placeholders sobrescritos a cada segundo pelos métodos
    // Refresh*, então não precisam de tradução aqui.
    [HarmonyPatch]
    public static class ClockPanelCreateUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("PlayIt.Panels.ClockPanel"), "CreateUI");

        [HarmonyPostfix]
        public static void Postfix(object __instance)
        {
            UiTreeTranslator.Traduzir("playit", (UIComponent)__instance);
        }
    }
}
