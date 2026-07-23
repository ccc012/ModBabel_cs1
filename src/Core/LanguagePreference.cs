using System.IO;
using System.Linq;
using System.Reflection;
using ColossalFramework.Plugins;

namespace ModBabel.Core
{
    // Lê/salva o idioma escolhido pelo jogador na tela de opções do
    // ModBabel. Independente do idioma do próprio jogo, porque o CS1
    // não oferece pt-BR (nem vários outros idiomas) nativamente.
    public static class LanguagePreference
    {
        private const string IdiomaPadrao = "pt-BR";
        private static string _idiomaEmCache;

        public static string IdiomaAtual()
        {
            if (_idiomaEmCache != null)
                return _idiomaEmCache;

            var caminho = CaminhoConfig();
            _idiomaEmCache = caminho != null && File.Exists(caminho)
                ? File.ReadAllText(caminho).Trim()
                : IdiomaPadrao;

            return _idiomaEmCache;
        }

        public static void Definir(string idioma)
        {
            _idiomaEmCache = idioma;

            var caminho = CaminhoConfig();
            if (caminho != null)
                File.WriteAllText(caminho, idioma);

            TranslationEngine.LimparCache();
            ForcarRecarregamentoDasAbasDeOpcoes();
        }

        // O Content Manager do CS1 monta a UI de opções de cada mod uma
        // única vez e reaproveita o painel — só reconstrói quando o
        // PluginManager avisa que a lista de plugins mudou (isEnabled).
        // Sem isso, trocar o idioma aqui não atualizava as abas já abertas
        // do Rainfall (só via desativar/reativar o ModBabel manualmente,
        // descoberto pelo usuário em 2026-07-23). Replicamos esse toggle
        // sozinhos para o usuário não precisar fazer isso na mão.
        private static void ForcarRecarregamentoDasAbasDeOpcoes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var pluginInfo = PluginManager.instance.FindPluginInfo(assembly);
            if (pluginInfo == null)
                return;

            pluginInfo.isEnabled = false;
            pluginInfo.isEnabled = true;
        }

        private static string CaminhoConfig()
        {
            var pastaMod = ModFolder.Caminho();
            return string.IsNullOrEmpty(pastaMod)
                ? null
                : Path.Combine(pastaMod, "modbabel_idioma.cfg");
        }
    }
}
