using HarmonyLib;

namespace ModBabel.Modules.RealisticWinds
{
    // Mod original: "Improved Wind Simulation" (nome do assembly e do
    // Workshop mais antigo: "Realistic Winds") por BloodyPenguin
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=627096876
    // Código-fonte: https://github.com/bloodypenguin/Skylines-RealisticWinds (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class RealisticWindsModule : Core.IModule
    {
        public string ModuloId => "realisticwinds";

        public string AssemblyDoModOriginal => "RealisticWinds";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
