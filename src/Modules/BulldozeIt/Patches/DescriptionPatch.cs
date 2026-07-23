using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BulldozeIt.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("BulldozeIt.ModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("bulldozeit", "Mod_Description", __result);
        }
    }
}
