using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.ExpressBusServices.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("ExpressBusServices.ExpressBusServices"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("expressbusservices", "Mod_Description", __result);
        }
    }
}
