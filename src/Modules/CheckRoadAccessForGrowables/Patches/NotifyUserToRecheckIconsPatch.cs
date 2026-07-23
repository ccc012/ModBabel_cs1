using System.Reflection;
using ColossalFramework.Plugins;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.CheckRoadAccessForGrowables.Patches
{
    // NotifyUserToRecheckIcons() é um método privado de 1 linha (chama
    // DebugOutputPanel.AddMessage com um texto fixo) - seguro reimplementar
    // via Prefix (retorna false) em vez de tentar interceptar a
    // string por dentro do método original.
    [HarmonyPatch]
    public static class NotifyUserToRecheckIconsPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("CheckRoadAccessForGrowables.Mod"),
                "NotifyUserToRecheckIcons");

        [HarmonyPrefix]
        public static bool Prefix()
        {
            const string original =
                "Recheck road access completed. Look for 'No Road Access' icons on your map.";

            DebugOutputPanel.AddMessage(
                PluginManager.MessageType.Warning,
                TranslationEngine.Traduzir("checkroadaccessforgrowables", original, original));

            return false;
        }
    }
}
