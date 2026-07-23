using HarmonyLib;

namespace ModBabel.Modules.SpecializedIndustryFixRedux
{
    // Mod original: "Specialized Industry Fix Redux" por Vectorial1024
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1553517176
    // Código-fonte: https://github.com/Vectorial1024/SpecializedIndustryFixRedux (aberto)
    // Confirmado contra o binário instalado (2026-07-24). Mod sem tela
    // de opções - só a descrição do Content Manager.
    public class SpecializedIndustryFixReduxModule : Core.IModule
    {
        public string ModuloId => "specializedindustryfixredux";

        public string AssemblyDoModOriginal => "SpecializedIndustryFixRedux";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
