using HarmonyLib;

namespace ModBabel.Modules.EmptyIt
{
    // Mod original: "Empty It!" por Keallu
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=1661072176
    // Código-fonte: https://github.com/keallu/CSL-EmptyIt (aberto)
    // Confirmado contra o binário instalado (2026-07-24).
    //
    // Diferente do Bulldoze It!/Play It! (mesmo autor), aqui a
    // estratégia foi mais simples: em vez de reimplementar
    // OnSettingsUI inteiro via Prefix, um Postfix roda o
    // UiTreeTranslator genérico no painel resultante (helper.self) -
    // funciona porque o método original não faz nenhum cast frágil
    // nem exige que a gente intercepte literais antes da criação, só
    // usa o UIHelper padrão normalmente. Mais simples de manter e já
    // ganha a troca de idioma ao vivo de graça (via
    // TranslatedComponentRegistry).
    public class EmptyItModule : Core.IModule
    {
        public string ModuloId => "emptyit";

        public string AssemblyDoModOriginal => "EmptyIt";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.OnSettingsUIPatch)).Patch();
        }
    }
}
