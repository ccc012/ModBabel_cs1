using System;
using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.BulldozeIt.Patches
{
    // BulldozeIt.ModInfo.OnSettingsUI monta a tela com o UIHelper padrão
    // do jogo, mas todos os textos (1 dropdown com 6 opções, 1 campo de
    // texto, 4 checkboxes) são literais hardcoded, sem campo
    // interceptável antes do método original rodar. Prefix pula o
    // original (retorna false) e remonta a mesma tela já traduzida,
    // lendo/escrevendo BulldozeIt.ModConfig.Instance via reflection
    // (Traverse) - mesmo padrão usado no Play It! (ver
    // Modules/PlayIt/Patches/OnSettingsUIPatch.cs).
    [HarmonyPatch]
    public static class OnSettingsUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("BulldozeIt.ModInfo"), "OnSettingsUI");

        private static readonly int[] IntervalValues = { 1, 2, 3, 4, 5, 6 };

        [HarmonyPrefix]
        public static bool Prefix(object __instance, UIHelperBase helper)
        {
            var config = Traverse.Create(AccessTools.TypeByName("BulldozeIt.ModConfig")).Property("Instance").GetValue();
            var t = Traverse.Create(config);

            var versao = __instance.GetType().Assembly.GetName().Version;
            var group = helper.AddGroup($"Bulldoze It! - {versao.Major}.{versao.Minor}");

            var intervalOriginais = new[]
            {
                "End of Day", "End of Month", "End of Year",
                "Every 5 seconds", "Every 10 seconds", "Every 30 seconds",
            };
            var intervalLabels = new string[intervalOriginais.Length];
            for (var i = 0; i < intervalOriginais.Length; i++)
                intervalLabels[i] = Traduzir(intervalOriginais[i]);

            var interval = t.Property("Interval").GetValue<int>();
            var indiceAtual = Array.IndexOf(IntervalValues, interval);
            if (indiceAtual < 0) indiceAtual = 0;

            var dropdownInterval = group.AddDropdown(Traduzir("Interval"), intervalLabels, indiceAtual, sel =>
            {
                t.Property("Interval").SetValue(IntervalValues[sel]);
                t.Method("Save").GetValue();
            });
            TranslatedComponentRegistry.RegistrarDropdown("bulldozeit", dropdownInterval as UIDropDown, intervalOriginais);

            var maxBuildings = t.Property("MaxBuildingsPerInterval").GetValue<int>();
            group.AddTextfield(Traduzir("Max Buildings (per interval)"), maxBuildings.ToString(), sel =>
            {
                int.TryParse(sel, out var resultado);
                t.Property("MaxBuildingsPerInterval").SetValue(resultado);
                t.Method("Save").GetValue();
            });

            AddCheckbox(group, t, "PreserveHistoricalBuildings", "Preserve Historical Buildings");
            AddCheckbox(group, t, "IgnoreSearchingForSurvivors", "Ignore Searching For Survivors");
            AddCheckbox(group, t, "ShowCounters", "Show Counters in Bulldozer Bar");
            AddCheckbox(group, t, "ShowStatistics", "Show Statistics in Info Panel");

            return false; // pula o método original - já remontamos a tela traduzida
        }

        private static void AddCheckbox(UIHelperBase group, Traverse configTraverse, string propriedade, string textoOriginal)
        {
            var valor = configTraverse.Property(propriedade).GetValue<bool>();
            var checkbox = group.AddCheckbox(Traduzir(textoOriginal), valor, sel =>
            {
                configTraverse.Property(propriedade).SetValue(sel);
                configTraverse.Method("Save").GetValue();
            });
            TranslatedComponentRegistry.RegistrarLabel("bulldozeit", (checkbox as UICheckBox)?.label, textoOriginal);
        }

        private static string Traduzir(string texto) =>
            TranslationEngine.Traduzir("bulldozeit", texto, texto);
    }
}
