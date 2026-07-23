using HarmonyLib;

namespace ModBabel.Modules.CustomEffectLoader
{
    // Mod original: "Custom Effect Loader" por boformer
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1886877404
    // Código-fonte: https://github.com/boformer/CustomEffectLoader (aberto)
    // Confirmado contra o binário instalado (2026-07-24): AssemblyName
    // e tipo "CustomEffectLoader.Mod" batem com o código-fonte. Mod sem
    // tela de opções - só a descrição do Content Manager.
    public class CustomEffectLoaderModule : Core.IModule
    {
        public string ModuloId => "customeffectloader";

        public string AssemblyDoModOriginal => "CustomEffectLoader";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
