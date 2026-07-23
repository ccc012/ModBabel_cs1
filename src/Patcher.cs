using CitiesHarmony.API;

namespace ModBabel
{
    // Classe isolada: só ela referencia HarmonyLib diretamente, para
    // evitar falha de carregamento caso o mod "Harmony" não esteja
    // instalado/ativo quando o ModBabel é carregado.
    public static class Patcher
    {
        private const string HarmonyId = "com.modbabel.cs1";

        public static void PatchAll()
        {
            HarmonyHelper.DoOnHarmonyReady(() =>
            {
                Core.Logger.Log("Harmony pronto - ativando módulos.");

                var harmony = new HarmonyLib.Harmony(HarmonyId);

                // Cada módulo só aplica seus patches se o mod original
                // dele estiver presente - ver Core/ModuleRegistry.cs
                Core.ModuleRegistry.AtivarModulosDisponiveis(harmony);
            });
        }

        public static void UnpatchAll()
        {
            if (HarmonyLib.Harmony.HasAnyPatches(HarmonyId))
            {
                new HarmonyLib.Harmony(HarmonyId).UnpatchAll(HarmonyId);
                Core.Logger.Log("Todos os patches removidos (mod desativado).");
            }
        }
    }
}
