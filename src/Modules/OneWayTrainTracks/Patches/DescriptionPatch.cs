using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.OneWayTrainTracks.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("SingleTrainTrack.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("onewaytraintracks", "Mod_Description", __result);
        }
    }
}
