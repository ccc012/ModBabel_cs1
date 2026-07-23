using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.PublicTransportUnstucker.Patches
{
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.PropertyGetter(
                AccessTools.TypeByName("PublicTransportUnstucker.PublicTransportUnstucker"), "Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("publictransportunstucker", "Mod_Description", __result);
        }
    }
}
