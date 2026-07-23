using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.CheckRoadAccessForGrowables.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("CheckRoadAccessForGrowables.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("checkroadaccessforgrowables", "Mod_Description", __result);
        }
    }
}
