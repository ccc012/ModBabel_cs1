using System.IO;

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

            // TENTATIVA ANTERIOR (revertida em 2026-07-23): forçar
            // pluginInfo.isEnabled = false/true aqui pra tentar disparar
            // uma reconstrução automática das abas de opções já abertas
            // de outros mods. Causava uma travada perceptível (o
            // PluginManager dispara um evento de "lista de plugins
            // mudou" que reconstrói a tela de mods inteira do Content
            // Manager - operação pesada por natureza) e, mesmo assim, o
            // usuário reportou que o idioma continuava não aplicando.
            // Sem conseguir testar em jogo nesta máquina, não dá pra
            // confirmar o mecanismo exato de quando o CS1 reconstrói a
            // aba de opções de um mod - a forma confiável conhecida é
            // fechar e reabrir o Content Manager (ver aviso na própria
            // tela de opções do ModBabel, OnSettingsUI).
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
