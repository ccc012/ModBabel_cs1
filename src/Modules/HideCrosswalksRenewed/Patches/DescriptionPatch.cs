using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.HideCrosswalksRenewed.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("HideCrosswalksRenewed.Lifecycle.HideCrosswalksRenewedMod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("hidecrosswalksrenewed", "Mod_Description", __result);
        }
    }
}
