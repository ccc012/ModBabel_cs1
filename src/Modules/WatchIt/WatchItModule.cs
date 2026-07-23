using HarmonyLib;

namespace ModBabel.Modules.WatchIt
{
    // Mod original: "Watch It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2863849354
    // Código-fonte: https://github.com/keallu/CSL-WatchIt (aberto)
    //
    // CUIDADO: AssemblyName real = "WatchItRevisited" (não "WatchIt"
    // como no código-fonte) - confirmado via reflection contra o
    // binário instalado (2026-07-24), mesmo tipo de divergência já
    // visto várias vezes. Classe continua "WatchIt.ModInfo".
    //
    // Mod grande (~5 grupos, ~40 chaves) - cobertura completa via
    // UiTreeTranslator, já que o custo extra é só escrever mais linhas
    // de XML, não código.
    public class WatchItModule : Core.IModule
    {
        public string ModuloId => "watchit";

        public string AssemblyDoModOriginal => "WatchItRevisited";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
