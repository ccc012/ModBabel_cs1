using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.EmptyIt.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(AccessTools.TypeByName("EmptyIt.ModInfo"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("emptyit", "Mod_Description", __result);
        }
    }
}
