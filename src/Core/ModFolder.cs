using System.Reflection;
using ColossalFramework.Plugins;

namespace ModBabel.Core
{
    // Resolve a pasta onde a DLL do ModBabel está instalada.
    //
    // NUNCA usar Assembly.Location para isso: o CS1 carrega assemblies de
    // mod via Assembly.Load(byte[]) (para permitir hot-reload e mods com
    // nomes duplicados), o que faz Location vir como string vazia e
    // quebra Path.GetDirectoryName com "ArgumentException: Invalid path"
    // - foi exatamente o erro visto ao testar no jogo (2026-07-23).
    //
    // A forma robusta e padrão da comunidade de modding do CS1 é perguntar
    // ao PluginManager, que sempre sabe o caminho real em disco de onde
    // o mod foi carregado (modPath), independente de como foi carregado.
    public static class ModFolder
    {
        private static string _caminhoEmCache;

        public static string Caminho()
        {
            if (_caminhoEmCache != null)
                return _caminhoEmCache;

            var assembly = Assembly.GetExecutingAssembly();
            var pluginInfo = PluginManager.instance.FindPluginInfo(assembly);

            _caminhoEmCache = pluginInfo != null ? pluginInfo.modPath : string.Empty;
            return _caminhoEmCache;
        }
    }
}
