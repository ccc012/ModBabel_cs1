using HarmonyLib;

namespace ModBabel.Modules.ExtraTrainStationTracks
{
    // Mod original: "Extra Train Station Tracks" por BloodyPenguin
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=515489008
    // Código-fonte: https://github.com/bloodypenguin/Skylines-ExtraTrainStationTracks (aberto)
    //
    // CUIDADO: o namespace/classe real é "ElevatedTrainStationTrack.Mod"
    // (singular, sem "Extra"), não bate com o nome do mod nem do
    // repositório - confirmado via reflection contra o binário
    // instalado (2026-07-24), mesmo tipo de divergência já visto no
    // Birdcage. AssemblyName também é "ElevatedTrainStationTrack".
    // Mod sem tela de opções - só a descrição do Content Manager.
    public class ExtraTrainStationTracksModule : Core.IModule
    {
        public string ModuloId => "extratrainstationtracks";

        public string AssemblyDoModOriginal => "ElevatedTrainStationTrack";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
