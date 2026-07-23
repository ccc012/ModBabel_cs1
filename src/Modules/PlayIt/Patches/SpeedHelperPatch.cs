using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.PlayIt.Patches
{
    // PlayIt.Helpers.SpeedHelper.FormatGameSpeed/FormatDayNightSpeed
    // retornam "Normal"/"Paused" (ou "<valor>%"/"<valor>x", que são
    // numéricos e não precisam de tradução) - mostrados no relógio
    // flutuante e nos sliders de velocidade do painel principal.
    [HarmonyPatch]
    public static class SpeedHelperPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("PlayIt.Helpers.SpeedHelper"), "FormatGameSpeed");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("playit", __result, __result);
        }
    }

    [HarmonyPatch]
    public static class DayNightSpeedHelperPatch
    {
        static MethodBase TargetMethod() =>
            AccessTools.Method(AccessTools.TypeByName("PlayIt.Helpers.SpeedHelper"), "FormatDayNightSpeed");

        [HarmonyPostfix]
        public static void Postfix(ref string __result)
        {
            __result = TranslationEngine.Traduzir("playit", __result, __result);
        }
    }
}
