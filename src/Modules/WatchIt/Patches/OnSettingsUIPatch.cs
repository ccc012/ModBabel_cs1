using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.WatchIt.Patches
{
    [HarmonyPatch]
    public static class OnSettingsUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("WatchIt.ModInfo"), "OnSettingsUI");

        [HarmonyPostfix]
        public static void Postfix(UIHelperBase helper)
        {
            if (helper is UIHelper concreto && concreto.self is UIComponent painel)
                UiTreeTranslator.Traduzir("watchit", painel);
        }
    }
}
