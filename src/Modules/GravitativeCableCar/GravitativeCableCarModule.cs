using HarmonyLib;

namespace ModBabel.Modules.GravitativeCableCar
{
    // Mod original: "Gravitative Cable Car" por sway2020
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2094830335
    // Código-fonte: https://github.com/sway2020/GravitativeCableCar (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class GravitativeCableCarModule : Core.IModule
    {
        public string ModuloId => "gravitativecablecar";

        public string AssemblyDoModOriginal => "GravitativeCableCar";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
