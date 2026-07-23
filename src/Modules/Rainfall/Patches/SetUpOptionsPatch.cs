using HarmonyLib;
using ICities;

namespace ModBabel.Modules.Rainfall.Patches
{
    // Estratégia usada para este mod (diferente do padrão "Prefix/Postfix
    // trocando um label específico" do template genérico): como TODAS as
    // strings do Rainfall são passadas como argumento literal para os
    // métodos Add* de UIHelperBase dentro de um único método
    // (OptionHandler.SetUpOptions), a forma mais robusta de traduzir é
    // substituir o próprio "helper" por um wrapper que intercepta cada
    // chamada Add* e traduz o texto antes de repassar para o helper real.
    //
    // Alvo real: Rainfall.UI.OptionHandler.SetUpOptions(UIHelperBase)
    // (nome de classe/método a confirmar exatamente no dnSpy contra a
    // versão instalada - o código-fonte público mostra essa assinatura,
    // mas o autor pode ter renomeado em alguma atualização)
    [HarmonyPatch]
    public static class SetUpOptionsPatch
    {
        // MethodBase alvo resolvido dinamicamente (em vez de
        // typeof(Rainfall.UI.OptionHandler) direto) porque este projeto
        // não referencia a DLL do mod original em tempo de compilação -
        // ver 06_TEMPLATE_HARMONY_PATCH.md (vault) sobre essa opção.
        static System.Reflection.MethodBase TargetMethod()
        {
            var tipoOriginal = AccessTools.TypeByName("Rainfall.UI.OptionHandler");
            return AccessTools.Method(tipoOriginal, "SetUpOptions");
        }

        [HarmonyPrefix]
        public static bool Prefix(ref UIHelperBase helper)
        {
            helper = new TranslatingUIHelper(helper, "rainfall");
            return true; // deixa o método original rodar, agora usando
                          // nosso helper "tradutor" no lugar do real
        }
    }
}
