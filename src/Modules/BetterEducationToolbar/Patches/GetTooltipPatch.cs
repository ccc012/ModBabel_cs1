using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterEducationToolbar.Patches
{
    // EducationUtils.GetTooltip(EducationCategory) recebe um enum que é
    // internal ao assembly original (não referenciado em tempo de
    // compilação aqui) - em vez de arriscar problema de boxing/tipo no
    // parâmetro do Postfix, extrai a chave direto do próprio __result:
    // todos os tooltips seguem o padrão "NomeDaCategoria - descrição",
    // então a chave de tradução é o texto antes de " - " (ex:
    // "Elementary"), sem precisar receber o enum original.
    [HarmonyPatch]
    public static class GetTooltipPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("BetterEducationToolbar.Patches.EducationUtils"),
                "GetTooltip");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            if (string.IsNullOrEmpty(__result)) return;

            var separador = __result.IndexOf(" - ");
            var chave = separador > 0 ? __result.Substring(0, separador) : __result;
            __result = TranslationEngine.Traduzir("bettereducationtoolbar", chave, __result);
        }
    }
}
