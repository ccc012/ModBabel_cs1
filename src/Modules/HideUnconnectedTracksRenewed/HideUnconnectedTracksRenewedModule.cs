using HarmonyLib;

namespace ModBabel.Modules.HideUnconnectedTracksRenewed
{
    // Mod original: "Hide TM:PE Unconnected Tracks Renewed" (fork
    // mantido por cylismaori)
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3704189586
    // Código-fonte de referência: https://github.com/cylismaori/HideUnconnectedTracks
    //
    // CUIDADO: AssemblyName real = "HideUnconnectedTracksRenewed",
    // classe real = "HideUnconnectedTracksRenewed.LifeCycle.CylisModInfo"
    // (não "HideUnconnectedTracks.LifeCycle.KianModInfo" do repositório
    // original do kian) - confirmado via reflection contra o binário
    // instalado (2026-07-24). Mod sem tela de opções - só a descrição
    // do Content Manager.
    public class HideUnconnectedTracksRenewedModule : Core.IModule
    {
        public string ModuloId => "hideunconnectedtracksrenewed";

        public string AssemblyDoModOriginal => "HideUnconnectedTracksRenewed";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
