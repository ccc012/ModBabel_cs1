using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.CustomEffectLoader.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("CustomEffectLoader.Mod"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("customeffectloader", "Mod_Description", __result);
        }
    }
}
