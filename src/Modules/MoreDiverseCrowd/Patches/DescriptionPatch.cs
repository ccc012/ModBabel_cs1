using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.MoreDiverseCrowd.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("DiverseCrowd.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("morediversecrowd", "Mod_Description", __result);
        }
    }
}
