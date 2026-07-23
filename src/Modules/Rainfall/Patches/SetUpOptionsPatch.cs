using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Rainfall.Patches
{
    // Traduz o dicionário estático Rainfall.OptionHandler.fullOptionGroupNames
    // (nome completo de cada grupo/aba de opções - ex: "GEN1" ->
    // "General Settings 1"). Esse dicionário alimenta 3 lugares ao mesmo
    // tempo dentro de SetUpOptions: o tooltip da aba, o texto do grupo
    // passado a helper.AddGroup(...), e a base do texto do botão
    // "Reset <nome>". Traduzir o dicionário uma vez, antes do método
    // original rodar, resolve os 3 de uma vez.
    //
    // Confirmado por decompilação da Rainfall.dll instalada (2026-07-23):
    // Rainfall.OptionHandler.SetUpOptions(UIHelperBase) existe com esse
    // nome e assinatura exatos; fullOptionGroupNames é
    // "private static Dictionary<string, string>".
    [HarmonyPatch]
    public static class SetUpOptionsPatch
    {
        private static bool _traduzido;

        static MethodBase TargetMethod()
        {
            var tipoOriginal = AccessTools.TypeByName("Rainfall.OptionHandler");
            return AccessTools.Method(tipoOriginal, "SetUpOptions");
        }

        [HarmonyPrefix]
        public static void Prefix()
        {
            if (_traduzido) return; // dicionário estático - só precisa traduzir 1 vez
            _traduzido = true;

            var tipoOriginal = AccessTools.TypeByName("Rainfall.OptionHandler");
            var campo = AccessTools.Field(tipoOriginal, "fullOptionGroupNames");
            var dicionario = (Dictionary<string, string>)campo.GetValue(null);

            var chaves = new List<string>(dicionario.Keys);
            foreach (var chave in chaves)
            {
                dicionario[chave] = TranslationEngine.Traduzir(
                    "rainfall", dicionario[chave], dicionario[chave]);
            }
        }
    }
}
