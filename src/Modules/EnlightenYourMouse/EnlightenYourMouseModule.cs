using HarmonyLib;

namespace ModBabel.Modules.EnlightenYourMouse
{
    // Mod original: "EYM: Enlighten Your Mouse" por algernon-A
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2455665392
    // Código-fonte: https://github.com/algernon-A/EnlightenYourMouse (aberto)
    //
    // Usa o framework AlgernonCommons (AlgernonCommons.Translation.
    // Translations.Translate(chave)) - mas, diferente do ModsCommon
    // (que é um shared project compilado dentro de cada mod), o
    // AlgernonCommons é uma DLL DE VERDADE, separada, distribuída junto
    // com cada mod que o usa. Isso significa que, se o jogador tiver
    // outro mod do algernon-A instalado, existem MÚLTIPLAS cópias
    // carregadas de "AlgernonCommons.dll" ao mesmo tempo - uma busca
    // global por nome pegaria uma cópia qualquer, não necessariamente a
    // do EnlightenYourMouse. Por isso o patch usa AssemblyResolver
    // (Core/AssemblyResolver.cs) pra achar especificamente a cópia de
    // AlgernonCommons carregada JUNTO com o assembly
    // "EnlightenYourMouse" (via PluginManager.GetAssemblies()).
    //
    // Não tem pt-BR nem espanhol nativos (confirmado pelos .csv do
    // próprio mod) - cobertura completa das 10 chaves de tradução.
    public class EnlightenYourMouseModule : Core.IModule
    {
        public string ModuloId => "enlightenyourmouse";

        public string AssemblyDoModOriginal => "EnlightenYourMouse";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.TranslatePatch)).Patch();
        }
    }
}
