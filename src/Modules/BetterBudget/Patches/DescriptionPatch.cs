using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterBudget.Patches
{
    // BetterBudget.BBModInformation.Description é uma propriedade normal
    // (não implementação explícita de interface) com getter hardcoded.
    // Chave sintética "Mod_Description" porque o texto original tem
    // quebras de linha, que um atributo XML normalizaria pra espaço.
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("BetterBudget.BBModInformation"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("betterbudget", "Mod_Description", __result);
        }
    }
}
