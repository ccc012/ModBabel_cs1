using HarmonyLib;

namespace ModBabel.Modules.BetterEducationToolbar
{
    // Mod original: "Better Education Toolbar" por t1a2l e Chamëleon TBN
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2810536248
    // Código-fonte: https://github.com/t1a2l/BetterEducationToolbar (aberto)
    //
    // Confirmado lendo o código-fonte público (2026-07-23, mod instalado
    // nesta máquina, feito sem testar em jogo, só pt-BR):
    // - AssemblyName = "BetterEducationToolbar"
    // - Mod.Description é IMPLEMENTAÇÃO EXPLÍCITA de interface
    //   ("string IUserMod.Description => ..."), então o getter não
    //   aparece como "Description"/"get_Description" via reflection -
    //   o nome real em IL é "ICities.IUserMod.get_Description"
    //   (confirmado via reflection contra a DLL instalada).
    // - Único outro texto visível do mod: os tooltips dos 4 botões de
    //   categoria (Elementary/HighSchool/Library/University), retornados
    //   por EducationUtils.GetTooltip(EducationCategory) - método
    //   estático limpo, sem precisar de UI tree walk. Traduz pela chave
    //   = nome do enum (ex: "Elementary").
    public class BetterEducationToolbarModule : Core.IModule
    {
        public string ModuloId => "bettereducationtoolbar";

        public string AssemblyDoModOriginal => "BetterEducationToolbar";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.GetTooltipPatch)).Patch();
        }
    }
}
