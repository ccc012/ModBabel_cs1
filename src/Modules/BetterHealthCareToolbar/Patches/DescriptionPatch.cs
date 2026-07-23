using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BetterHealthCareToolbar.Patches
{
    // Mesma implementação explícita de interface do BetterEducationToolbar
    // ("string IUserMod.Description => ..."), então o método compilado
    // também se chama "ICities.IUserMod.get_Description" - a convenção de
    // nomes pra implementação explícita de interface é do compilador C#,
    // não muda entre mods diferentes que implementam a mesma interface.
    [HarmonyPatch]
    public static class DescriptionPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(
                AccessTools.TypeByName("BetterHealthCareToolbar.Mod"),
                "ICities.IUserMod.get_Description");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("betterhealthcaretoolbar", "Mod_Description", __result);
        }
    }
}
