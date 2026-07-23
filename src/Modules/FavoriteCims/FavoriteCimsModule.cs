using HarmonyLib;

namespace ModBabel.Modules.FavoriteCims
{
    // Mod original: "Favorite Cims" por will258012 (fork mantido, mod
    // original mais antigo)
    // Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3058339497
    // Código-fonte: https://github.com/will258012/FavoriteCims (aberto)
    //
    // CUIDADO: a classe principal real é "FavoriteCims.FavoriteCimsModMain"
    // (não "FavoriteCims.Mod") - confirmado via reflection contra o
    // binário instalado (2026-07-24).
    //
    // Mesmo framework AlgernonCommons do EnlightenYourMouse (ver notas
    // lá) - patch usa AssemblyResolver pra achar a cópia certa de
    // AlgernonCommons.dll.
    //
    // COBERTURA PARCIAL nesta primeira passada: o mod tem ~150 chaves
    // de tradução, a maioria descrevendo status detalhado de cidadãos
    // (nível de educação, riqueza, saúde, fase de vida, etc - dezenas
    // de combinações Male/Female). Traduzidas só as chaves da UI
    // principal (descrição, botões do menu, cabeçalhos de coluna,
    // tooltips das estrelinhas de favorito). PENDENTE: todas as chaves
    // de status detalhado de cidadão (Education_*, Health_Level_*,
    // AgePhase_*, Low/Mid/High_Wealth_*, etc).
    public class FavoriteCimsModule : Core.IModule
    {
        public string ModuloId => "favoritecims";

        public string AssemblyDoModOriginal => "FavoriteCims";

        public void AplicarPatches(Harmony harmony)
        {
            harmony.CreateClassProcessor(typeof(Patches.TranslatePatch)).Patch();
        }
    }
}
