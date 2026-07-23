using System.Reflection;
using ColossalFramework.UI;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.PlayIt.Patches
{
    // PlayIt.Panels.MainPanel.CreateUI() monta o painel flutuante inteiro
    // (abas World/Weather/Advanced) com textos hardcoded. Postfix roda
    // depois do método original, com a árvore de UIComponent já pronta -
    // só falta traduzir cada texto encontrado nela.
    [HarmonyPatch]
    public static class MainPanelCreateUIPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("PlayIt.Panels.MainPanel"), "CreateUI");

        [HarmonyPostfix]
        public static void Postfix(object __instance)
        {
            UiTreeTranslator.Traduzir("playit", (UIComponent)__instance);
        }
    }
}
