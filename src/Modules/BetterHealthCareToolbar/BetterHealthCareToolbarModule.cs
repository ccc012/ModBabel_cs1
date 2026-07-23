using HarmonyLib;

namespace ModBabel.Modules.BetterHealthCareToolbar
{
    // Mod original: "Better HealthCare Toolbar" por t1a2l
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2559042012
    // Código-fonte: https://github.com/t1a2l/BetterHealthCareToolbar (aberto)
    //
    // Mesma estrutura exata do BetterEducationToolbar (mesmo autor,
    // mesmo padrão de código) - ver notas lá. Só muda o assembly, a
    // classe utilitária (HealthCareUtils) e as 5 categorias
    // (HealthCare/DeathCare/ChildCare/ElderCare/RecreationalCare em vez
    // de Elementary/HighSchool/Library/University).
    public class BetterHealthCareToolbarModule : Core.IModule
    {
        public string ModuloId => "betterhealthcaretoolbar";

        public string AssemblyDoModOriginal => "BetterHealthCareToolbar";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.DescriptionPatch)).Patch();
            harmony.CreateClassProcessor(typeof(Patches.GetTooltipPatch)).Patch();
        }
    }
}
