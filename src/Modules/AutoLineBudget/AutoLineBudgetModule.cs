using HarmonyLib;

namespace ModBabel.Modules.AutoLineBudget
{
    // Mod original: "Auto Line Budget 21" por jakeluba
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2349240408
    // Código-fonte: https://github.com/jakeluba/AutoLineBudget21 (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "AutoLineBudget" (repositório se chama
    //   "AutoLineBudget21", mas o assembly compilado não - conferido
    //   direto na pasta de mods instalada)
    // - Mod muito simples, sem tela de opções: só ajusta o orçamento das
    //   linhas de transporte automaticamente a cada 5 segundos. O único
    //   texto visível é a descrição no Content Manager
    //   (IUserMod.Description, propriedade com getter hardcoded).
    // - Há também duas mensagens de Chirper geradas dinamicamente dentro
    //   do loop principal (Update()) quando o orçamento de uma linha
    //   muda bastante ("X is more frequent now..."/"X is not so empty
    //   anymore...") - não traduzidas nesta versão: os textos são
    //   montados e usados na hora, sem passar por nenhum campo/
    //   dicionário interceptável, e patchar o método MessageManager.
    //   TryCreateMessage (usado por dezenas de sistemas do próprio jogo)
    //   só pra pegar essas duas frases seria frágil demais pro ganho.
    public class AutoLineBudgetModule : Core.IModule
    {
        public string ModuloId => "autolinebudget";

        public string AssemblyDoModOriginal => "AutoLineBudget";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
        }
    }
}
