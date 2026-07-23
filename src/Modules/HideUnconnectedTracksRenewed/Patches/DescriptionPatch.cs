using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.HideUnconnectedTracksRenewed.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("HideUnconnectedTracksRenewed.LifeCycle.CylisModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("hideunconnectedtracksrenewed", "Mod_Description", __result);
        }
    }
}
