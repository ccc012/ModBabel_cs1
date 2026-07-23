using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.WatchIt.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("WatchIt.ModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("watchit", "Mod_Description", __result);
        }
    }
}
