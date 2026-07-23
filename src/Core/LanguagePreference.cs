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
