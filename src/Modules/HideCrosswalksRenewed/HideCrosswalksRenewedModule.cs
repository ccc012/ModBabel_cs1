using HarmonyLib;

namespace ModBabel.Modules.HideCrosswalksRenewed
{
    // Mod original: "Hide TM:PE Crosswalks: Renewed" (fork mantido de
    // "kian.zarrin")
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3682758360
    // Código-fonte de referência: https://github.com/CitiesSkylinesMods/HideCrosswalks
    //
    // CUIDADO: o binário instalado ("HideCrosswalksRenewed.dll") é um
    // fork renomeado - AssemblyName = "HideCrosswalksRenewed", classe
    // real = "HideCrosswalksRenewed.Lifecycle.HideCrosswalksRenewedMod"
    // (não "HideCrosswalks.Lifecycle.HideCrosswalksMod" como no
    // repositório original) - confirmado via reflection contra o
    // binário instalado (2026-07-24), mesmo tipo de divergência já
    // visto no Birdcage. Mod sem tela de opções - só a descrição do
    // Content Manager.
    public class HideCrosswalksRenewedModule : Core.IModule
    {
        public string ModuloId => "hidecrosswalksrenewed";

        public string AssemblyDoModOriginal => "HideCrosswalksRenewed";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
