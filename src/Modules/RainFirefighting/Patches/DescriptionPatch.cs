using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.RainFirefighting.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("RainFirefighting.ModIdentity"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("rainfirefighting", "Mod_Description", __result);
        }
    }
}
