using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.RealisticWinds.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("RealisticWinds.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("realisticwinds", "Mod_Description", __result);
        }
    }
}
