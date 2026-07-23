using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.CheckRoadAccessForGrowables.Patches
{
    [HarmonyPatch]
    public static class OptionsUIPatches
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("CheckRoadAccessForGrowables.Mod"),
                "AddRecheckRoadAccessButtonToOptions");

        [HarmonyPostfix]
        public static void Postfix(UIHelperBase uiHelper)
        {
            if (uiHelper is UIHelper concreto && concreto.self is UIComponent painel)
                UiTreeTranslator.Traduzir("checkroadaccessforgrowables", painel);
        }
    }

    [HarmonyPatch]
    public static class GameplayOnlyMessagePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("CheckRoadAccessForGrowables.Mod"),
                "AddModCanOnlyBeUsedDuringGameplayMessageToOptions");

        [HarmonyPostfix]
        public static void Postfix(UIHelperBase uiHelper)
        {
            if (uiHelper is UIHelper concreto && concreto.self is UIComponent painel)
                UiTreeTranslator.Traduzir("checkroadaccessforgrowables", painel);
        }
    }
}
