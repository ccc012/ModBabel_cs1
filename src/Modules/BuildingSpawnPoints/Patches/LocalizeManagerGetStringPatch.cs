using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using ModBabel.Core;

namespace ModBabel.Modules.BuildingSpawnPoints.Patches
{
    // Mesmo raciocínio do AdvancedStopSelection: ModsCommon é um shared
    // project, cada mod compila sua própria cópia do tipo
    // ModsCommon.LocalizeManager - por isso a busca é escopada ao
    // assembly "BuildingSpawnPoints" especificamente, não global.
    [HarmonyPatch]
    public static class LocalizeManagerGetStringPatch
    {
        static MethodBase TargetMethod()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == "BuildingSpawnPoints");

            var tipo = assembly?.GetType("ModsCommon.LocalizeManager");
            return tipo == null
                ? null
                : AccessTools.Method(tipo, "GetString", new[] { typeof(string), typeof(CultureInfo) });
        }

        [HarmonyPostfix]
        public static void Postfix(string key, ref string __result)
        {
            __result = TranslationEngine.Traduzir("buildingspawnpoints", key, __result);
        }
    }
}
