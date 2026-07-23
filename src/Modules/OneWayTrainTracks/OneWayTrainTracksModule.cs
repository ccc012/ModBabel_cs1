using HarmonyLib;

namespace ModBabel.Modules.OneWayTrainTracks
{
    // Mod original: "One-Way Train Tracks" por BloodyPenguin
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=724382534
    // Código-fonte: https://github.com/bloodypenguin/Skylines-OneWayTrainTracks (aberto)
    //
    // Classe real "SingleTrainTrack.Mod" (namespace do repo,
    // confirmado contra o binário instalado, 2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class OneWayTrainTracksModule : Core.IModule
    {
        public string ModuloId => "onewaytraintracks";

        public string AssemblyDoModOriginal => "SingleTrainTrack";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
