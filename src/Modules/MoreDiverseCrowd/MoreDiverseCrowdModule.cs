using HarmonyLib;

namespace ModBabel.Modules.MoreDiverseCrowd
{
    // Mod original: "More Diverse Crowd" por BloodyPenguin
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=578320825
    // Código-fonte: https://github.com/bloodypenguin/Skylines-MoreDiverseCrowd (aberto)
    //
    // Classe real "DiverseCrowd.Mod" (namespace do repo), AssemblyName
    // "DiverseCrowd" - confirmado contra o binário instalado
    // (2026-07-24). Mod sem tela de opções - só a descrição do
    // Content Manager.
    public class MoreDiverseCrowdModule : Core.IModule
    {
        public string ModuloId => "morediversecrowd";

        public string AssemblyDoModOriginal => "DiverseCrowd";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
