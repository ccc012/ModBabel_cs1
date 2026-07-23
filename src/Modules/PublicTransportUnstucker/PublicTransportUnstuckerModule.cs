using HarmonyLib;

namespace ModBabel.Modules.PublicTransportUnstucker
{
    // Mod original: "Public Transport Unstucker" por Vectorial1024
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2774427140
    // Código-fonte: https://github.com/Vectorial1024/PublicTransportUnstucker (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class PublicTransportUnstuckerModule : Core.IModule
    {
        public string ModuloId => "publictransportunstucker";

        public string AssemblyDoModOriginal => "PublicTransportUnstucker";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
