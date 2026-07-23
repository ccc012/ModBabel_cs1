using HarmonyLib;

namespace ModBabel.Modules.AdvancedStopSelection
{
    // Mod original: "Advanced Stop Selection" por BloodyPenguin e macsergey
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2862973068
    // Código-fonte: https://github.com/MacSergey/ImprovedStopSelection (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, sem o mod
    // instalado nesta máquina - feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "AdvancedStopSelection"
    // - Diferente do Rainfall e do Play It!, este mod já usa um
    //   framework próprio de localização (ModsCommon, compartilhado
    //   entre vários mods do mesmo autor - Node Controller, Intersection
    //   Marking Tool, etc.) com arquivos .resx e fallback por
    //   CultureInfo. Já vem com inglês + russo prontos.
    // - Só que ModsCommon é um "shared project" (.projitems) - cada mod
    //   compila sua PRÓPRIA cópia do tipo ModsCommon.LocalizeManager
    //   dentro do próprio assembly, não é uma DLL compartilhada entre
    //   mods instalados. Por isso o patch busca o tipo especificamente
    //   dentro do assembly "AdvancedStopSelection" (não um
    //   AccessTools.TypeByName global) - evita pegar o tipo errado se o
    //   jogador tiver outro mod do mesmo autor instalado também.
    // - O texto específico deste mod (não o framework genérico) é bem
    //   pequeno: só a descrição do mod e as mensagens de cada versão
    //   ("What's New"), todas expostas como propriedades estáticas em
    //   AdvancedStopSelection.Localize que chamam
    //   LocaleManager.GetString(chave, cultura). Postfix nesse
    //   GetString traduz pela CHAVE do recurso (ex: "Mod_Description"),
    //   não pelo texto - mais estável que o texto em si, que muda de
    //   idioma pra idioma dentro do próprio resx original.
    // - Não tentamos traduzir as strings genéricas do framework
    //   ModsCommon (abas "General"/"Notifications" etc.) nesta primeira
    //   versão - são muitas e compartilhadas entre vários mods, fora de
    //   escopo por ora. Only ficam sem tradução (fallback automático).
    public class AdvancedStopSelectionModule : Core.IModule
    {
        public string ModuloId => "advancedstopselection";

        public string AssemblyDoModOriginal => "AdvancedStopSelection";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.LocalizeManagerGetStringPatch)).Patch();
        }
    }
}
