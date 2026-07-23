using HarmonyLib;

namespace ModBabel.Modules.PlayIt
{
    // Mod original: "Play It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2741726428
    // Código-fonte: https://github.com/keallu/CSL-PlayIt (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, o autor não
    // instalado nesta máquina - módulo feito sem testar em jogo, só
    // pt-BR nesta primeira versão):
    // - AssemblyName = "PlayIt", RootNamespace = "PlayIt"
    // - Ao contrário do Rainfall, o Play It! NÃO usa o UIHelper padrão do
    //   jogo pra montar a maior parte da sua UI: ele cria um UIPanel
    //   próprio do zero (PlayIt.Panels.MainPanel, aberto por um botão
    //   flutuante) com todos os textos (labels, tooltips, checkboxes,
    //   dropdowns) como literais hardcoded direto no código C#, dentro
    //   de um método privado CreateUI(). Não dá pra interceptar os
    //   literais com um Prefix (eles não vêm de um campo/dicionário
    //   traduzível como no Rainfall) - a solução foi um Postfix em
    //   CreateUI que percorre a árvore de UIComponent já montada e
    //   traduz cada texto encontrado (ver Core/UiTreeTranslator.cs e
    //   Patches/MainPanelCreateUIPatch.cs).
    // - PlayIt.Panels.ClockPanel (o relógio flutuante) segue o mesmo
    //   padrão - mesmo Postfix genérico.
    // - PlayIt.ModInfo.OnSettingsUI (a aba do mod no Content Manager,
    //   via IUserMod padrão) tem só 4 controles com literais hardcoded -
    //   como não tem como interceptar literais com Prefix, a solução foi
    //   pular o método original (Prefix retornando false) e remontar a
    //   mesma tela com os textos traduzidos.
    // - "Normal"/"Paused" (mostrados no relógio flutuante e nos
    //   sliders de velocidade) vêm de PlayIt.Helpers.SpeedHelper -
    //   patch separado nesses dois métodos estáticos.
    // - Limitação conhecida: o texto "Game"/"System" do relógio flutuante
    //   (alternado com duplo-clique) não foi traduzido nesta versão -
    //   fica em inglês, igual as mensagens do Chirper no Rainfall.
    public class PlayItModule : Core.IModule
    {
        public string ModuloId => "playit";

        public string AssemblyDoModOriginal => "PlayIt";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.MainPanelCreateUIPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.ClockPanelCreateUIPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.SpeedHelperPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.DayNightSpeedHelperPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
