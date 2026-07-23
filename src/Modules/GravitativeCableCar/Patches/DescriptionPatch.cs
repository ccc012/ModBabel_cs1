using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.GravitativeCableCar.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("GravitativeCableCar.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("gravitativecablecar", "Mod_Description", __result);
        }
    }
}
