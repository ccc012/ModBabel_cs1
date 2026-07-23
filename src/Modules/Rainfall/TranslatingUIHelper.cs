using ColossalFramework.UI;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.Rainfall
{
    // Decorator sobre um UIHelperBase real: cada Add* recebe o texto em
    // inglês, procura a tradução (usando o próprio texto original como
    // chave - este mod não define um sistema de chaves próprio) e repassa
    // ao helper real já traduzido.
    //
    // ATENÇÃO: a assinatura exata de ICities.UIHelperBase precisa ser
    // conferida contra o ICities.dll instalado antes de compilar - os
    // métodos abaixo refletem a interface pública conhecida da
    // comunidade de modding do CS1, mas podem ter mudado entre versões
    // do jogo. Ajustar assinaturas conforme necessário.
    public class TranslatingUIHelper : UIHelperBase
    {
        private readonly UIHelperBase _real;
        private readonly string _moduloId;

        public TranslatingUIHelper(UIHelperBase real, string moduloId)
        {
            _real = real;
            _moduloId = moduloId;
        }

        private string T(string original) =>
            TranslationEngine.Traduzir(_moduloId, original, original);

        public UIComponent self => _real.self;

        public UIHelperBase AddGroup(string text) =>
            new TranslatingUIHelper(_real.AddGroup(T(text)), _moduloId);

        public object AddButton(string text, OnButtonClicked eventCallback) =>
            _real.AddButton(T(text), eventCallback);

        public object AddCheckbox(string text, bool defaultValue, OnCheckChanged eventCallback) =>
            _real.AddCheckbox(T(text), defaultValue, eventCallback);

        public object AddDropdown(string text, string[] options, int defaultSelection, OnDropdownSelectionChanged eventCallback)
        {
            var opcoesTraduzidas = new string[options.Length];
            for (var i = 0; i < options.Length; i++)
                opcoesTraduzidas[i] = T(options[i]);

            return _real.AddDropdown(T(text), opcoesTraduzidas, defaultSelection, eventCallback);
        }

        public object AddSlider(string text, float min, float max, float step, float defaultValue, OnValueChanged eventCallback) =>
            _real.AddSlider(T(text), min, max, step, defaultValue, eventCallback);

        public object AddTextfield(string text, string defaultContent, OnTextChanged eventChangedCallback, OnTextSubmitted eventSubmittedCallback) =>
            _real.AddTextfield(T(text), defaultContent, eventChangedCallback, eventSubmittedCallback);

        public object AddSpace(int height) => _real.AddSpace(height);
    }
}
