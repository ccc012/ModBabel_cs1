using HarmonyLib;

namespace ModBabel.Modules.Birdcage
{
    // Mod original: "Birdcage - More Chirper controls" por SexyFishHorse
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=649147853
    // Código-fonte: https://github.com/SexyFishHorse/CitiesSkylines-Birdcage (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName real = "SexyFishHorse.CitiesSkylines.Birdcage"
    //   (dll instalada: SexyFishHorse.CitiesSkylines.Birdcage.dll)
    // - Description é override normal (não implementação explícita de
    //   interface) de uma classe base UserModBase vinda de outro
    //   assembly separado (SexyFishHorse.CitiesSkylines.Infrastructure.dll,
    //   de fato outra DLL, não um shared project como ModsCommon/
    //   AlgernonCommons) - AccessTools.PropertyGetter funciona direto.
    // - PENDÊNCIA: a tela de opções (Appearance/Behaviour/Debugging,
    //   5 checkboxes/botões) usa um wrapper próprio do autor
    //   (IStronglyTypedUIHelper, da Infrastructure.dll) em vez do
    //   ICities.UIHelperBase direto - os textos são literais passados
    //   direto pros métodos desse wrapper, sem campo interceptável.
    //   Traduzir isso exigiria reimplementar o método inteiro via
    //   reflection encadeada (Traverse em cada .AddGroup/.AddCheckBox/
    //   .AddButton do wrapper, já que o tipo não é referenciado em tempo
    //   de compilação) - desproporcional pro tamanho da tela nesta
    //   primeira passada. Só a descrição do Content Manager foi
    //   traduzida por ora.
    public class BirdcageModule : Core.IModule
    {
        public string ModuloId => "birdcage";

        public string AssemblyDoModOriginal => "SexyFishHorse.CitiesSkylines.Birdcage";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
