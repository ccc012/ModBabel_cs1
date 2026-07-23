using System.Diagnostics;
using System.Reflection;
using ICities;
using ModBabel.Core;

namespace ModBabel
{
    public class ModEntryPoint : IUserMod
    {
        private const string GitHubIssuesUrl = "https://github.com/ccc012/ModBabel_cs1/issues";

        // Nome com a versão do assembly junto (ex: "ModBabel 1.0.0.0") -
        // mesmo padrão que outros mods usam (ex: "Move It 2.10.9"),
        // ajuda muito na hora de reportar um bug.
        public string Name => $"ModBabel {Assembly.GetExecutingAssembly().GetName().Version}";

        public string Description =>
            "Traduz outros mods do Workshop para o idioma de sua " +
            "preferência (pt-BR e outros). Requer o Harmony e os mods " +
            "originais que você quiser traduzir. Não afiliado a nenhum " +
            "dos autores dos mods traduzidos.";

        public void OnEnabled()
        {
            Patcher.PatchAll();
        }

        public void OnDisabled()
        {
            Patcher.UnpatchAll();
        }

        // Tela de opções do mod (Content Manager → Mods → ModBabel → Options)
        //
        // ICities.UIHelperBase não tem um AddLabel genérico (só
        // AddGroup/AddButton/AddCheckbox/AddSlider/AddDropdown/
        // AddTextfield/AddSpace, confirmado via reflection contra o
        // ICities.dll instalado, 2026-07-23) - por isso avisos/contadores
        // vão no próprio título do grupo em vez de texto solto.
        //
        // O Content Manager do CS1 monta a UI de opções de cada mod uma
        // vez e reaproveita o painel - trocar o idioma aqui não
        // atualiza na hora as abas de outros mods que já estavam
        // abertas. Sem conseguir testar em jogo nesta máquina, a forma
        // confiável conhecida de forçar a reconstrução é fechar e abrir
        // o Content Manager de novo (ver LanguagePreference.cs para o
        // histórico de uma tentativa de automatizar isso que causava
        // travada e foi revertida).
        public void OnSettingsUI(UIHelperBase helper)
        {
            // Botões de apoio ao projeto, no topo da tela (mesmo padrão
            // usado por outros mods, ex: Move It com "Buy Me A Coffee"/
            // "Patreon"/"Paypal"). Links de Ko-fi/LivePix ainda são
            // placeholders - ver Core/SupportLinks.cs.
            var grupoApoio = helper.AddGroup("ModBabel - Apoie o projeto");
            grupoApoio.AddButton("Ko-fi", () => UnityEngine.Application.OpenURL(SupportLinks.KoFi));
            grupoApoio.AddButton("LivePix", () => UnityEngine.Application.OpenURL(SupportLinks.LivePix));
            grupoApoio.AddButton("Reportar um bug (GitHub)", () => UnityEngine.Application.OpenURL(GitHubIssuesUrl));

            var group = helper.AddGroup(
                "ModBabel - Idioma (feche e reabra o Content Manager após trocar)");

            var idiomas = TranslationEngine.IdiomasDisponiveis();
            var atual = LanguagePreference.IdiomaAtual();
            var indiceAtual = System.Array.IndexOf(idiomas, atual);

            group.AddDropdown(
                "Idioma de tradução",
                idiomas,
                indiceAtual < 0 ? 0 : indiceAtual,
                selecionado => LanguagePreference.Definir(idiomas[selecionado])
            );

            // Contador de módulos ativos vai no título do grupo (sem
            // AddLabel disponível). Só reflete a realidade depois que
            // Patcher.PatchAll() já rodou (Harmony fica pronto de forma
            // assíncrona via HarmonyHelper.DoOnHarmonyReady) - se essa
            // tela for aberta cedo demais no carregamento, pode mostrar
            // 0 até o Content Manager ser reaberto.
            var grupoLog = helper.AddGroup(
                $"ModBabel - Diagnóstico ({ModuleRegistry.ModulosAtivados} de " +
                $"{ModuleRegistry.TotalModulos} mods traduzidos detectados nesta partida)");

            grupoLog.AddCheckbox(
                "Habilitar log detalhado (salva em ModBabel.log, na pasta do mod)",
                LogPreference.Habilitado(),
                habilitado => LogPreference.Definir(habilitado)
            );

            grupoLog.AddButton("Abrir pasta de log", () =>
            {
                var pastaMod = ModFolder.Caminho();
                if (!string.IsNullOrEmpty(pastaMod))
                    Process.Start(pastaMod);
            });
        }
    }
}
