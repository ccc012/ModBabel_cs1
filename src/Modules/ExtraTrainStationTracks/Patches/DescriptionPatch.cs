using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ExtraTrainStationTracks.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("ElevatedTrainStationTrack.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("extratrainstationtracks", "Mod_Description", __result);
        }
    }
}
