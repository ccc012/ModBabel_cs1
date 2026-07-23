using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.PlayIt.Patches
{
    // PlayIt.ModInfo.OnSettingsUI monta a aba do mod no Content Manager
    // com o UIHelper padrão do jogo (igual o Rainfall), mas os 4 textos
    // (1 checkbox + 3 botões) são literais hardcoded, sem passar por
    // nenhum campo/dicionário interceptável antes do método original
    // rodar. Como são só 4 controles simples, a solução foi pular o
    // método original (Prefix retornando false) e remontar a mesma tela
    // com os textos traduzidos, lendo/escrevendo PlayIt.ModConfig.Instance
    // e chamando PlayIt.ModProperties.Instance via reflection (Traverse) -
    // os tipos originais não são referenciados em tempo de compilação.
    [HarmonyPatch]
    public static class OnSettingsUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("PlayIt.ModInfo"), "OnSettingsUI");

        [HarmonyPrefix]
        public static bool Prefix(object __instance, UIHelperBase helper)
        {
            var tipoConfig = AccessTools.TypeByName("PlayIt.ModConfig");
            var config = Traverse.Create(tipoConfig).Property("Instance").GetValue();
            var configTraverse = Traverse.Create(config);

            var tipoProperties = AccessTools.TypeByName("PlayIt.ModProperties");
            var properties = Traverse.Create(tipoProperties).Property("Instance").GetValue();
            var propertiesTraverse = Traverse.Create(properties);

            var versao = __instance.GetType().Assembly.GetName().Version;
            var group = helper.AddGroup($"Play It! - {versao.Major}.{versao.Minor}");

            var mostrarBotao = configTraverse.Property("ShowButton").GetValue<bool>();
            const string textoShowButton = "Show Button";
            var checkboxShowButton = group.AddCheckbox(
                TranslationEngine.Traduzir("playit", textoShowButton, textoShowButton),
                mostrarBotao,
                selecionado =>
                {
                    configTraverse.Property("ShowButton").SetValue(selecionado);
                    configTraverse.Method("Save").GetValue();
                });
            TranslatedComponentRegistry.RegistrarLabel("playit", (checkboxShowButton as UICheckBox)?.label, textoShowButton);

            group.AddSpace(10);

            const string textoResetPanel = "Reset Positioning of Panel";
            var botaoResetPanel = group.AddButton(
                TranslationEngine.Traduzir("playit", textoResetPanel, textoResetPanel),
                () => propertiesTraverse.Method("ResetPanelPosition").GetValue());
            TranslatedComponentRegistry.RegistrarBotao("playit", botaoResetPanel as UIButton, textoResetPanel);

            group.AddSpace(10);

            const string textoResetButton = "Reset Positioning of Button";
            var botaoResetButton = group.AddButton(
                TranslationEngine.Traduzir("playit", textoResetButton, textoResetButton),
                () => propertiesTraverse.Method("ResetButtonPosition").GetValue());
            TranslatedComponentRegistry.RegistrarBotao("playit", botaoResetButton as UIButton, textoResetButton);

            group.AddSpace(10);

            const string textoResetClock = "Reset Positioning of Clock";
            var botaoResetClock = group.AddButton(
                TranslationEngine.Traduzir("playit", textoResetClock, textoResetClock),
                () => propertiesTraverse.Method("ResetClockPosition").GetValue());
            TranslatedComponentRegistry.RegistrarBotao("playit", botaoResetClock as UIButton, textoResetClock);

            return false; // pula o método original - já remontamos a tela traduzida
        }
    }
}
