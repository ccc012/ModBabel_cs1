using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ICities;
using ModBabel.Core;

namespace ModBabel.Modules.EmptyIt.Patches
{
    // EmptyIt.ModInfo.OnSettingsUI usa o UIHelper padrão do jogo
    // normalmente (sem casts frágeis) - deixa o método original rodar e
    // usa um Postfix pra traduzir a árvore de UI resultante inteira de
    // uma vez, incluindo todos os grupos condicionados por DLC
    // (Warehouses, Landfill Sites, Waste Transfer Facilities,
    // Cemeteries, Snow Dumps).
    [HarmonyPatch]
    public static class OnSettingsUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("EmptyIt.ModInfo"), "OnSettingsUI");

        [HarmonyPostfix]
        public static void Postfix(UIHelperBase helper)
        {
            if (helper is UIHelper concreto && concreto.self is UIComponent painel)
                UiTreeTranslator.Traduzir("emptyit", painel);
        }
    }
}
