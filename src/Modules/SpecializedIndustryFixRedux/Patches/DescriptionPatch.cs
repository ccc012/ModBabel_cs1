using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.SpecializedIndustryFixRedux.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("SpecializedIndustryFixRedux.SpecializedIndustryFixRedux"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("specializedindustryfixredux", "Mod_Description", __result);
        }
    }
}
