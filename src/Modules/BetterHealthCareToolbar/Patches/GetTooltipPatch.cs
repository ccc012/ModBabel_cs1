using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterHealthCareToolbar.Patches
{
    // Mesma ideia do BetterEducationToolbar: extrai a chave direto do
    // __result ("NomeDaCategoria - descrição") em vez de receber o enum
    // HealthCareCategory como parâmetro do Postfix.
    [HarmonyPatch]
    public static class GetTooltipPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("BetterHealthCareToolbar.Patches.HealthCareUtils"),
                "GetTooltip");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;

            var separador = __result.IndexOf(" - ");
            var chave = separador > 0 ? __result.Substring(0, separador) : __result;
            __result = TranslationEngine.Traduzir("betterhealthcaretoolbar", chave, __result);
        }
    }
}
