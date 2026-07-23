using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.EnlightenYourMouse.Patches
{
    [HarmonyPatch]
    public static class TranslatePatch
    {
        static MethodBase TargetMethod()
        {
            var algernonCommons = AssemblyResolver.EncontrarAssemblyIrma("EnlightenYourMouse", "AlgernonCommons");
            var tipo = algernonCommons?.GetType("AlgernonCommons.Translation.Translations");
            return tipo == null ? null : AccessTools.Method(tipo, "Translate", new[] { typeof(string) });
        }

        [HarmonyPostfix]
        public static void Postfix(string key, ref string __result)
        {
            __result = TranslationEngine.Traduzir("enlightenyourmouse", key, __result);
        }
    }
}
