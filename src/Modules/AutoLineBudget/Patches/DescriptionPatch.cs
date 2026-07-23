using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.AutoLineBudget.Patches
{
    // AutoLineBudget.AutoLineBudget.Description é uma propriedade com
    // getter hardcoded (retorna a string direto, sem campo/dicionário
    // intermediário) - por isso o patch mira o método get_Description
    // (nome padrão gerado pelo compilador pra propriedades) e troca o
    // resultado depois que ele já rodou.
    //
    // Usa uma CHAVE SINTÉTICA fixa ("Mod_Description") em vez do texto
    // original como chave de tradução - o texto original tem quebras de
    // linha (\n\n), e um atributo XML normaliza qualquer quebra de linha
    // pra espaço (regra do próprio padrão XML, "attribute-value
    // normalization"), então usar o texto multi-linha como chave nunca
    // bateria com o __result em tempo de execução (a tradução cairia no
    // fallback silenciosamente).
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("AutoLineBudget.AutoLineBudget"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("autolinebudget", "Mod_Description", __result);
        }
    }
}
