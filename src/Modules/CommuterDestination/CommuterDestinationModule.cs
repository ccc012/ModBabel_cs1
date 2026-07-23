using HarmonyLib;

namespace ModBabel.Modules.CommuterDestination
{
    // Mod original: "Commuter Destination" por Jameskmonger
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2475986859
    // Código-fonte: https://github.com/Jameskmonger/CSL-ShowCommuterDestination (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName real = "CommuterDestination.CS1" (o mod é composto
    //   por 2 DLLs: CommuterDestination.Core.dll com a lógica, e
    //   CommuterDestination.CS1.dll com o IUserMod e a integração com o
    //   jogo - detectamos pela presença desta última).
    // - Description é propriedade normal. A tela de opções
    //   (SettingsUI.BuildPanel) monta um grupo "Integrations" com um
    //   label dinâmico ("Improved Public Transport 2: Detected/Not
    //   detected") - Postfix com o UiTreeTranslator genérico cobre os
    //   dois de uma vez.
    public class CommuterDestinationModule : Core.IModule
    {
        public string ModuloId => "commuterdestination";

        public string AssemblyDoModOriginal => "CommuterDestination.CS1";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.BuildPanelPatch)).Patch();
        }
    }
}
