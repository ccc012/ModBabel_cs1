using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BrokenNodeDetector.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("BrokenNodeDetector.BrokenNodeDetector"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("brokennodedetector", "Mod_Description", __result);
        }
    }
}
