using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.AdvancedStopSelection.Patches
{
    // ModsCommon.LocalizeManager.GetString(chave, cultura) é o ponto
    // único por onde toda string localizável deste mod passa (tanto as
    // próprias do mod - AdvancedStopSelection.Localize - quanto as
    // genéricas do framework - CommonLocalize -, já que ambas usam o
    // mesmo tipo ModsCommon.LocalizeManager). O tipo é buscado
    // especificamente dentro do assembly "AdvancedStopSelection" (não
    // globalmente) porque cada mod baseado em ModsCommon compila sua
    // própria cópia desse tipo - um AccessTools.TypeByName comum poderia
    // pegar a cópia de outro mod do mesmo autor instalado junto.
    [HarmonyPatch]
    public static class LocalizeManagerGetStringPatch
    {
        static MethodBase TargetMethod()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == "AdvancedStopSelection");

            var tipo = assembly?.GetType("ModsCommon.LocalizeManager");
            return tipo == null
                ? null
                : AccessTools.Method(tipo, "GetString", new[] { typeof(string), typeof(CultureInfo) });
        }

        [HarmonyPostfix]
        public static void Postfix(string key, ref string __result)
        {
            __result = TranslationEngine.Traduzir("advancedstopselection", key, __result);
        }
    }
}
