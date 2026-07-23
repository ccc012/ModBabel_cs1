using HarmonyLib;

namespace ModBabel.Modules.RainFirefighting
{
    // Mod original: "Rain Firefighting" por yury-sch
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=629370088
    // Código-fonte: https://github.com/yury-sch/RainFirefighting (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class RainFirefightingModule : Core.IModule
    {
        public string ModuloId => "rainfirefighting";

        public string AssemblyDoModOriginal => "RainFirefighting";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
