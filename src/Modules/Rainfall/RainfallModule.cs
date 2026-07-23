using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.Rainfall
{
    // Mod original: "Rainfall" por [SSU]yenyang
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=698395457
    // Código-fonte: https://github.com/yenyang/rainfall (MIT, aberto)
    //
    // Confirmado por decompilação da Rainfall.dll instalada (2026-07-23,
    // ilspycmd contra o build que o Steam Workshop baixou nesta máquina):
    // - Sem sistema de locale próprio (o autor confirmou nos comentários
    //   do Workshop: "I never made localization for this mod")
    // - AssemblyName = "Rainfall", namespace único "Rainfall" (não
    //   "Rainfall.UI" como o código-fonte público no GitHub sugeria)
    // - Todas as strings de UI passam por 5 classes pequenas
    //   (OptionsCheckbox/Dropdown/Button/Slider/OptionResetButton), cada
    //   uma com um Create(UIHelperBase) que lê campos (readableName,
    //   units, uniqueName) antes de chamar helper.AddX(...) - ver
    //   Patches/OptionsItemPatches.cs
    // - O SetUpOptions(UIHelperBase) do OptionHandler NÃO pode ser
    //   interceptado trocando o parâmetro "helper" por um wrapper: o
    //   código faz um cast direto pra UIHelper concreto logo na primeira
    //   linha (para pegar o UIComponent raiz e montar a tabstrip nativa),
    //   e cria instâncias de UIHelper NOVAS internamente pra cada aba -
    //   um wrapper customizado quebraria esse cast. Por isso o nome
    //   completo de cada grupo/aba é traduzido separadamente, direto no
    //   dicionário estático fullOptionGroupNames - ver
    //   Patches/SetUpOptionsPatch.cs
    // - ROTA 2 (Harmony patch) confirmada como necessária
    public class RainfallModule : IModule
    {
        public string ModuloId => "rainfall";

        public string AssemblyDoModOriginal => "Rainfall";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.SetUpOptionsPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionsCheckboxCreatePatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionsDropdownCreatePatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionsButtonCreatePatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionsSliderCreatePatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionResetButtonCreatePatch)).Patch();
        }
    }
}
