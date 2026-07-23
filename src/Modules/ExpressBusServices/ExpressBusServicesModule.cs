using HarmonyLib;

namespace ModBabel.Modules.ExpressBusServices
{
    // Mod original: "Express Bus Services" por Vectorial1024
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2262054175
    // Código-fonte: https://github.com/Vectorial1024/ExpressBusServices (aberto)
    // Confirmado contra o binário instalado (2026-07-24).
    //
    // OnSettingsUI usa o UIHelper padrão normalmente (monta 3 grupos:
    // ônibus, bonde e metrô, cada um com dropdown de modo) - mesmo
    // padrão do Empty It!, Postfix com UiTreeTranslator no painel
    // resultante.
    //
    // PENDÊNCIA: a variante "Express Bus Services (TLM Plugin: t1a2l
    // Variation)" (Workshop 3015128256, assembly
    // "ExpressBusServices_TLM_t1a2l") não teve código-fonte público
    // encontrado nesta passada - não implementado ainda.
    public class ExpressBusServicesModule : Core.IModule
    {
        public string ModuloId => "expressbusservices";

        public string AssemblyDoModOriginal => "ExpressBusServices";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
