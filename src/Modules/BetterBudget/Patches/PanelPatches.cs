using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterBudget.Patches
{
    // Os 3 painéis customizados do Better Budget montam a UI inteira
    // dentro de um método público "initialize(...)" - cada classe com
    // uma assinatura diferente, mas todas resolvidas por nome (só existe
    // 1 overload de "initialize" por classe). Postfix roda o walker
    // genérico (Core/UiTreeTranslator.cs) depois que o painel já foi
    // montado.
    [HarmonyPatch]
    public static class UICustomBudgetPanelPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("BetterBudget.UICustomBudgetPanel"), "initialize");

        [HarmonyPostfix]
        public static void Postfix(object __instance)
        {
            UiTreeTranslator.Traduzir("betterbudget", (UIComponent)__instance);
        }
    }

    [HarmonyPatch]
    public static class UICustomBudgetPanelSelectorPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("BetterBudget.UICustomBudgetPanelSelector"), "initialize");

        [HarmonyPostfix]
        public static void Postfix(object __instance)
        {
            UiTreeTranslator.Traduzir("betterbudget", (UIComponent)__instance);
        }
    }

    [HarmonyPatch]
    public static class UIEmbeddedBudgetPanelSelectorPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("BetterBudget.UIEmbeddedBudgetPanelSelector"), "initialize");

        [HarmonyPostfix]
        public static void Postfix(object __instance)
        {
            UiTreeTranslator.Traduzir("betterbudget", (UIComponent)__instance);
        }
    }
}
