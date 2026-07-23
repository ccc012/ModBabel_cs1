using System.Collections.Generic;
using ColossalFramework.UI;

namespace ModBabel.Core
{
    // Registro de todo componente de UI que o ModBabel já traduziu,
    // junto do texto ORIGINAL em inglês (nunca o texto já traduzido).
    //
    // É isso que permite trocar de idioma com um clique só, sem
    // reiniciar o jogo: guardando o original, dá pra re-traduzir
    // qualquer componente a qualquer momento, pra qualquer idioma -
    // sem isso, a segunda troca de idioma tentaria traduzir a partir do
    // texto que já está na tela (que pode já estar em outro idioma, não
    // em inglês), e nunca bateria com nenhuma chave do XML.
    //
    // Funciona mesmo com a aba fechada/escondida: o componente de UI em
    // si continua vivo na memória enquanto o mod original não for
    // desativado - só precisa estar registrado aqui, não visível.
    public static class TranslatedComponentRegistry
    {
        private readonly struct Entrada
        {
            public readonly string ModuloId;
            public readonly string TextoOriginal;

            public Entrada(string moduloId, string textoOriginal)
            {
                ModuloId = moduloId;
                TextoOriginal = textoOriginal;
            }
        }

        private readonly struct EntradaDropdown
        {
            public readonly string ModuloId;
            public readonly string[] ItensOriginais;

            public EntradaDropdown(string moduloId, string[] itensOriginais)
            {
                ModuloId = moduloId;
                ItensOriginais = itensOriginais;
            }
        }

        private static readonly Dictionary<UILabel, Entrada> Labels = new Dictionary<UILabel, Entrada>();
        private static readonly Dictionary<UIButton, Entrada> Botoes = new Dictionary<UIButton, Entrada>();
        private static readonly Dictionary<UIComponent, Entrada> Tooltips = new Dictionary<UIComponent, Entrada>();
        private static readonly Dictionary<UIDropDown, EntradaDropdown> Dropdowns =
            new Dictionary<UIDropDown, EntradaDropdown>();

        public static void RegistrarLabel(string moduloId, UILabel label, string textoOriginal)
        {
            if (label == null) return;
            Labels[label] = new Entrada(moduloId, textoOriginal);
        }

        public static void RegistrarBotao(string moduloId, UIButton botao, string textoOriginal)
        {
            if (botao == null) return;
            Botoes[botao] = new Entrada(moduloId, textoOriginal);
        }

        public static void RegistrarTooltip(string moduloId, UIComponent componente, string textoOriginal)
        {
            if (componente == null) return;
            Tooltips[componente] = new Entrada(moduloId, textoOriginal);
        }

        public static void RegistrarDropdown(string moduloId, UIDropDown dropdown, string[] itensOriginais)
        {
            if (dropdown == null) return;
            Dropdowns[dropdown] = new EntradaDropdown(moduloId, itensOriginais);
        }

        // Chamado sempre que o jogador troca o idioma. Passa por tudo
        // que já foi registrado e reaplica a tradução a partir do texto
        // original guardado - ao vivo, sem precisar fechar o Content
        // Manager nem reiniciar o jogo.
        public static void RetraduzirTudo()
        {
            foreach (var par in Labels)
            {
                if (par.Key == null) continue; // componente destruído
                par.Key.text = TranslationEngine.Traduzir(par.Value.ModuloId, par.Value.TextoOriginal, par.Value.TextoOriginal);
            }

            foreach (var par in Botoes)
            {
                if (par.Key == null) continue;
                par.Key.text = TranslationEngine.Traduzir(par.Value.ModuloId, par.Value.TextoOriginal, par.Value.TextoOriginal);
            }

            foreach (var par in Tooltips)
            {
                if (par.Key == null) continue;
                par.Key.tooltip = TranslationEngine.Traduzir(par.Value.ModuloId, par.Value.TextoOriginal, par.Value.TextoOriginal);
            }

            foreach (var par in Dropdowns)
            {
                if (par.Key == null) continue;

                var moduloId = par.Value.ModuloId;
                var itensOriginais = par.Value.ItensOriginais;
                var novosItens = new string[itensOriginais.Length];
                for (var i = 0; i < itensOriginais.Length; i++)
                    novosItens[i] = TranslationEngine.Traduzir(moduloId, itensOriginais[i], itensOriginais[i]);

                par.Key.items = novosItens;
            }
        }
    }
}
