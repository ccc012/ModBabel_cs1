using ColossalFramework.UI;

namespace ModBabel.Core
{
    // Walker genérico para mods que montam a própria UI customizada em
    // vez de usar o UIHelper padrão do jogo (ex: Play It!, que cria um
    // UIPanel próprio com Awake/Start/CreateUI ao invés de implementar
    // OnSettingsUI). Como UIComponent/UILabel/UIButton/UICheckBox/
    // UIDropDown já são tipos do ColossalManaged (referenciados em tempo
    // de compilação por este projeto), dá pra percorrer a árvore de
    // componentes com tipos fortes, sem reflection - mesmo sem
    // referenciar o assembly do mod original, já que o "root" chega aqui
    // via cast de object/instância concreta (a classe real do painel é
    // internal ao mod original, mas ela sempre herda de UIComponent).
    //
    // Traduz UILabel.text, UIButton.text (cobre também o label de
    // UICheckBox, que é um UILabel filho comum) e UIDropDown.items,
    // além do tooltip de qualquer componente. Usa o próprio texto em
    // inglês como chave de tradução (mesma convenção usada no módulo
    // Rainfall) - itens sem entrada no XML do idioma caem no fallback
    // (mantém o texto original).
    //
    // Cada componente traduzido é registrado no
    // TranslatedComponentRegistry (com o texto ORIGINAL, antes de
    // traduzir) - é isso que permite trocar de idioma depois com um
    // clique só, sem reiniciar o jogo (ver TranslatedComponentRegistry).
    public static class UiTreeTranslator
    {
        public static void Traduzir(string moduloId, UIComponent raiz)
        {
            if (raiz == null) return;

            if (raiz is UILabel label && !string.IsNullOrEmpty(label.text))
            {
                var original = label.text;
                label.text = TranslationEngine.Traduzir(moduloId, original, original);
                TranslatedComponentRegistry.RegistrarLabel(moduloId, label, original);
            }

            if (raiz is UIButton button && !string.IsNullOrEmpty(button.text))
            {
                var original = button.text;
                button.text = TranslationEngine.Traduzir(moduloId, original, original);
                TranslatedComponentRegistry.RegistrarBotao(moduloId, button, original);
            }

            if (!string.IsNullOrEmpty(raiz.tooltip))
            {
                var original = raiz.tooltip;
                raiz.tooltip = TranslationEngine.Traduzir(moduloId, original, original);
                TranslatedComponentRegistry.RegistrarTooltip(moduloId, raiz, original);
            }

            if (raiz is UIDropDown dropdown && dropdown.items != null)
            {
                var itensOriginais = (string[])dropdown.items.Clone();
                var itens = dropdown.items;
                for (var i = 0; i < itens.Length; i++)
                    itens[i] = TranslationEngine.Traduzir(moduloId, itens[i], itens[i]);
                dropdown.items = itens; // reatribuir para a UI atualizar a lista
                TranslatedComponentRegistry.RegistrarDropdown(moduloId, dropdown, itensOriginais);
            }

            foreach (UIComponent filho in raiz.components)
                Traduzir(moduloId, filho);
        }
    }
}
