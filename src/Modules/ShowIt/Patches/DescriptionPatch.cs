using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ShowIt.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("ShowIt.ModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("showit", "Mod_Description", __result);
        }
    }
}
