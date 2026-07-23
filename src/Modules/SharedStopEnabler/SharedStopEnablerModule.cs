using HarmonyLib;

namespace ModBabel.Modules.SharedStopEnabler
{
    // Mod original: "SharedStopEnabler" por CodeBardian
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2096382380
    // Código-fonte: https://github.com/CodeBardian/SharedStopEnabler (aberto)
    //
    // CUIDADO: o namespace real é "SharedStopEnabler.SharedStops" (não
    // "SharedStops.SharedStops" como no código-fonte) - confirmado via
    // reflection contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class SharedStopEnablerModule : Core.IModule
    {
        public string ModuloId => "sharedstopenabler";

        public string AssemblyDoModOriginal => "SharedStopEnabler";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
