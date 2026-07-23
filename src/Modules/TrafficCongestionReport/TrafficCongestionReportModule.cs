using HarmonyLib;

namespace ModBabel.Modules.TrafficCongestionReport
{
    // Mod original: "Traffic Congestion Report" por pcfantasy
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1651036644
    // Código-fonte: https://github.com/pcfantasy/TrafficCongestionReport (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class TrafficCongestionReportModule : Core.IModule
    {
        public string ModuloId => "trafficcongestionreport";

        public string AssemblyDoModOriginal => "TrafficCongestionReport";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
