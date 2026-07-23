using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Birdcage.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("SexyFishHorse.CitiesSkylines.Birdcage.BirdcageUserMod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("birdcage", "Mod_Description", __result);
        }
    }
}
