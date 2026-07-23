using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Breakdown.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("Breakdown.BreakdownMod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("breakdown", "Mod_Description", __result);
        }
    }
}
