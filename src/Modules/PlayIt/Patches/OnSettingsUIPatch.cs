using System.Reflection;
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
            group.AddCheckbox(
                TranslationEngine.Traduzir("playit", "Show Button", "Show Button"),
                mostrarBotao,
                selecionado =>
                {
                    configTraverse.Property("ShowButton").SetValue(selecionado);
                    configTraverse.Method("Save").GetValue();
                });

            group.AddSpace(10);

            group.AddButton(
                TranslationEngine.Traduzir("playit", "Reset Positioning of Panel", "Reset Positioning of Panel"),
                () => propertiesTraverse.Method("ResetPanelPosition").GetValue());

            group.AddSpace(10);

            group.AddButton(
                TranslationEngine.Traduzir("playit", "Reset Positioning of Button", "Reset Positioning of Button"),
                () => propertiesTraverse.Method("ResetButtonPosition").GetValue());

            group.AddSpace(10);

            group.AddButton(
                TranslationEngine.Traduzir("playit", "Reset Positioning of Clock", "Reset Positioning of Clock"),
                () => propertiesTraverse.Method("ResetClockPosition").GetValue());

            return false; // pula o método original - já remontamos a tela traduzida
        }
    }
}
