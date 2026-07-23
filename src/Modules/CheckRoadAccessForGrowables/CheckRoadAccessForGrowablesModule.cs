using HarmonyLib;

namespace ModBabel.Modules.CheckRoadAccessForGrowables
{
    // Mod original: "Check Road Access for Growables" por egi (DaEgi01)
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2454302667
    // Código-fonte: https://github.com/DaEgi01/CitiesSkylines-CheckRoadAccessForGrowables (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "CheckRoadAccessForGrowables"
    // - OnSettingsUI monta UI diferente dependendo se está em jogo
    //   (botão "Recheck road access") ou fora (aviso "só funciona em
    //   jogo"), em dois métodos privados separados
    //   (AddRecheckRoadAccessButtonToOptions/
    //   AddModCanOnlyBeUsedDuringGameplayMessageToOptions). Em vez de
    //   reimplementar o método (que chama lógica real do jogo -
    //   SimulationManager/BuildingManager - arriscado replicar sem
    //   testar), Postfix em cada um desses métodos roda o
    //   UiTreeTranslator genérico (Core/UiTreeTranslator.cs) no painel
    //   recém-criado.
    // - A mensagem do DebugOutputPanel após clicar o botão
    //   (NotifyUserToRecheckIcons) foi traduzida com Prefix (método
    //   simples de 1 linha, seguro reimplementar).
    public class CheckRoadAccessForGrowablesModule : Core.IModule
    {
        public string ModuloId => "checkroadaccessforgrowables";

        public string AssemblyDoModOriginal => "CheckRoadAccessForGrowables";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OptionsUIPatches)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.NotifyUserToRecheckIconsPatch)).Patch();
        }
    }
}
