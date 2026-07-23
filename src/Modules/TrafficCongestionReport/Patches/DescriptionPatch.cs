using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.TrafficCongestionReport.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("TrafficCongestionReport.TrafficCongestionReport"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("trafficcongestionreport", "Mod_Description", __result);
        }
    }
}
