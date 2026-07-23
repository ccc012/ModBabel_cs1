using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ModuloExemplo
{
    // TEMPLATE - substituir typeof(...) e o nome do método pelo alvo
    // real, descoberto na extração de strings (dnSpy). Ver
    // 05_METODOLOGIA_EXTRACAO_STRINGS.md e 06_TEMPLATE_HARMONY_PATCH.md
    // no vault para o processo completo.
    //
    // [HarmonyPatch(typeof(ModOriginal.AlgumPainel), "Initialize")]
    public static class PatchExemplo
    {
        private const string ModuloId = "modulo-exemplo";

        [HarmonyPostfix]
        public static void Postfix(/* ModOriginal.AlgumPainel __instance */)
        {
            // Exemplo de uso do TranslationEngine com fallback automático:
            //
            // __instance.algumLabel.text = TranslationEngine.Traduzir(
            //     ModuloId, "LABEL_ALGUMA_COISA", "Original Text");
        }
    }
}
