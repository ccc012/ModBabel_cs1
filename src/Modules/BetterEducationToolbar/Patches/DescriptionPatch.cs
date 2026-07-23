using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterEducationToolbar.Patches
{
    // "string IUserMod.Description => ..." é implementação explícita de
    // interface - o método compilado se chama
    // "ICities.IUserMod.get_Description" (confirmado via reflection
    // contra a DLL instalada, 2026-07-23), não "get_Description" como
    // seria numa propriedade normal.
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("BetterEducationToolbar.Mod"),
                "ICities.IUserMod.get_Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("bettereducationtoolbar", "Mod_Description", __result);
        }
    }
}
