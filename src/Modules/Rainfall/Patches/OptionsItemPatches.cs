using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Rainfall.Patches
{
    // As classes internas do Rainfall (OptionsCheckbox, OptionsDropdown,
    // OptionsButton, OptionsSlider, OptionResetButton) guardam o texto de
    // UI em campos (readableName, units, uniqueName), lidos dentro de
    // cada Create(UIHelperBase) antes de chamar helper.AddCheckbox/
    // AddDropdown/AddButton/AddSlider. Como essas classes são "internal"
    // no assembly do Rainfall (não referenciado em tempo de compilação
    // por este projeto), os campos são lidos/escritos via reflection
    // (Traverse) em vez de tipos fortes - técnica padrão para traduzir
    // mods sem precisar referenciar a DLL original no build.
    //
    // Todos os nomes de classe/campo abaixo foram confirmados por
    // decompilação da Rainfall.dll instalada nesta máquina (2026-07-23).

    internal static class ModuleConstants
    {
        internal const string ModuloId = "rainfall";
    }

    [HarmonyPatch]
    public static class OptionsCheckboxCreatePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("Rainfall.OptionsCheckbox"), "Create");

        [HarmonyPrefix]
        public static void Prefix(object __instance)
        {
            var t = Traverse.Create(__instance);
            var original = t.Field("readableName").GetValue<string>();
            t.Field("readableName").SetValue(
                TranslationEngine.Traduzir(ModuleConstants.ModuloId, original, original));
        }
    }

    [HarmonyPatch]
    public static class OptionsDropdownCreatePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("Rainfall.OptionsDropdown"), "Create");

        [HarmonyPrefix]
        public static void Prefix(object __instance)
        {
            var t = Traverse.Create(__instance);

            var readableName = t.Field("readableName").GetValue<string>();
            t.Field("readableName").SetValue(
                TranslationEngine.Traduzir(ModuleConstants.ModuloId, readableName, readableName));

            var opcoes = t.Field("options").GetValue<List<string>>();
            for (var i = 0; i < opcoes.Count; i++)
                opcoes[i] = TranslationEngine.Traduzir(ModuleConstants.ModuloId, opcoes[i], opcoes[i]);
        }
    }

    [HarmonyPatch]
    public static class OptionsButtonCreatePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("Rainfall.OptionsButton"), "Create");

        [HarmonyPrefix]
        public static void Prefix(object __instance)
        {
            var t = Traverse.Create(__instance);
            var original = t.Field("readableName").GetValue<string>();
            t.Field("readableName").SetValue(
                TranslationEngine.Traduzir(ModuleConstants.ModuloId, original, original));
        }
    }

    [HarmonyPatch]
    public static class OptionsSliderCreatePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("Rainfall.OptionsSlider"), "Create");

        [HarmonyPrefix]
        public static void Prefix(object __instance)
        {
            var t = Traverse.Create(__instance);

            var readableName = t.Field("readableName").GetValue<string>();
            t.Field("readableName").SetValue(
                TranslationEngine.Traduzir(ModuleConstants.ModuloId, readableName, readableName));

            // "units" é o sufixo mostrado no tooltip do slider (ex: " units",
            // " min", " %", " seconds") - não faz parte de readableName
            var units = t.Field("units").GetValue<string>();
            t.Field("units").SetValue(
                TranslationEngine.Traduzir(ModuleConstants.ModuloId, units, units));
        }
    }

    [HarmonyPatch]
    public static class OptionResetButtonCreatePatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("Rainfall.OptionResetButton"), "Create");

        [HarmonyPrefix]
        public static void Prefix(object __instance)
        {
            // Este campo (uniqueName) é usado como TEXTO DO BOTÃO só nesta
            // classe (em OptionsCheckbox/Dropdown/Slider, uniqueName é
            // usado como chave de armazenamento no PlayerPrefs - não mexer
            // nesses). O valor chega aqui já como "Reset " + nome do grupo
            // JÁ TRADUZIDO (porque SetUpOptionsPatch traduz
            // fullOptionGroupNames antes do método original montar essa
            // string) - só falta traduzir a palavra "Reset " em si.
            var t = Traverse.Create(__instance);
            var texto = t.Field("uniqueName").GetValue<string>();
            t.Field("uniqueName").SetValue(texto.Replace("Reset ", "Redefinir "));
        }
    }
}
