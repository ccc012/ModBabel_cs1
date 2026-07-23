using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.SharedStopEnabler.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("SharedStopEnabler.SharedStops"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("sharedstopenabler", "Mod_Description", __result);
        }
    }
}
