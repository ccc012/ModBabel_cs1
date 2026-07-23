using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterTrainBoarding.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("BetterTrainBoarding.BetterTrainBoarding"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("bettertrainboarding", "Mod_Description", __result);
        }
    }
}
