using ICities;
using ModBabel.Core;

namespace ModBabel
{
    public class ModEntryPoint : IUserMod
    {
        public string Name => "ModBabel";

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
        // ICities.dll instalado, 2026-07-23) - por isso o aviso abaixo
        // vai no próprio título do grupo em vez de um texto solto.
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
        }
    }
}
