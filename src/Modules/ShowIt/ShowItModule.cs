using HarmonyLib;

namespace ModBabel.Modules.ShowIt
{
    // Mod original: "Show It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1556715327
    // Código-fonte: https://github.com/keallu/CSL-ShowIt (aberto)
    // Confirmado contra o binário instalado (2026-07-24). OnSettingsUI
    // usa o UIHelper padrão normalmente - Postfix com UiTreeTranslator.
    public class ShowItModule : Core.IModule
    {
        public string ModuloId => "showit";

        public string AssemblyDoModOriginal => "ShowIt";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
