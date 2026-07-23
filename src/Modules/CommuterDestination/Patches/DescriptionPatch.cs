using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.CommuterDestination.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("CommuterDestination.CS1.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("commuterdestination", "Mod_Description", __result);
        }
    }
}
