using HarmonyLib;

namespace ModBabel.Modules.Breakdown
{
    // Mod original: "Breakdown" por whyoh
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2439120274
    // Código-fonte: https://github.com/whyoh/CitiesBreakdown (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "Breakdown"
    // - O painel de UI (UIBreakdownPanel) só mostra dados dinâmicos
    //   (nomes de rota/contagens reais da cidade do jogador) - nada de
    //   texto estático pra traduzir ali. Único texto fixo é a descrição
    //   no Content Manager (propriedade normal).
    public class BreakdownModule : Core.IModule
    {
        public string ModuloId => "breakdown";

        public string AssemblyDoModOriginal => "Breakdown";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
