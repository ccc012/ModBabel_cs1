using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ToggleIt.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("ToggleIt.ModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("toggleit", "Mod_Description", __result);
        }
    }
}
