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
            _idiomaEmCache = File.Exists(caminho)
                ? File.ReadAllText(caminho).Trim()
                : IdiomaPadrao;

            return _idiomaEmCache;
        }

        public static void Definir(string idioma)
        {
            _idiomaEmCache = idioma;
            File.WriteAllText(CaminhoConfig(), idioma);
            TranslationEngine.LimparCache();
        }

        private static string CaminhoConfig()
        {
            var pastaModulo = Path.GetDirectoryName(
                typeof(LanguagePreference).Assembly.Location);
            return Path.Combine(pastaModulo, "modbabel_idioma.cfg");
        }
    }
}
