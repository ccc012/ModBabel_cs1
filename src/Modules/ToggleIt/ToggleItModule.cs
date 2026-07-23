using HarmonyLib;

namespace ModBabel.Modules.ToggleIt
{
    // Mod original: "Toggle It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1764637396
    // Código-fonte: https://github.com/keallu/CSL-ToggleIt (aberto)
    // Confirmado contra o binário instalado (2026-07-24).
    public class ToggleItModule : Core.IModule
    {
        public string ModuloId => "toggleit";

        public string AssemblyDoModOriginal => "ToggleIt";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
