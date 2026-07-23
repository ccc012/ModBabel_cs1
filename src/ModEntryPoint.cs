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
        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("ModBabel - Idioma");

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
