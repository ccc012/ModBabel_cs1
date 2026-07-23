using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ModBabel.Core
{
    // Carrega os arquivos Translations/[modulo]/[idioma].xml e resolve
    // qual string mostrar, com fallback para o texto original em inglês
    // se a tradução não existir no idioma escolhido.
    public static class TranslationEngine
    {
        // moduloId -> (chave -> texto traduzido) para o idioma atual
        private static readonly Dictionary<string, Dictionary<string, string>> _cache =
            new Dictionary<string, Dictionary<string, string>>();

        public static string Traduzir(string moduloId, string chave, string textoOriginal)
        {
            var idioma = LanguagePreference.IdiomaAtual();

            if (!_cache.TryGetValue(moduloId, out var mapa))
            {
                mapa = CarregarArquivo(moduloId, idioma);
                _cache[moduloId] = mapa;
            }

            return mapa.TryGetValue(chave, out var traduzido)
                ? traduzido
                : textoOriginal; // nunca mostra vazio/quebrado
        }

        public static void LimparCache()
        {
            _cache.Clear();
        }

        public static string[] IdiomasDisponiveis()
        {
            // Idiomas conhecidos = união de todos os arquivos .xml
            // encontrados em qualquer pasta Translations/[modulo]/
            var pastaBase = Path.Combine(
                Path.GetDirectoryName(typeof(TranslationEngine).Assembly.Location),
                "Translations");

            if (!Directory.Exists(pastaBase))
                return new[] { "en" };

            var idiomas = Directory.GetDirectories(pastaBase)
                .SelectMany(Directory.GetFiles)
                .Select(Path.GetFileNameWithoutExtension)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

            return idiomas.Length > 0 ? idiomas : new[] { "en" };
        }

        private static Dictionary<string, string> CarregarArquivo(string moduloId, string idioma)
        {
            var resultado = new Dictionary<string, string>();

            var caminho = Path.Combine(Path.Combine(Path.Combine(
                Path.GetDirectoryName(typeof(TranslationEngine).Assembly.Location),
                "Translations"), moduloId), idioma + ".xml");

            if (!File.Exists(caminho))
                return resultado; // sem arquivo = tudo cai no fallback (texto original)

            var doc = XDocument.Load(caminho);
            foreach (var el in doc.Descendants("String"))
            {
                var chave = (string)el.Attribute("key");
                if (chave != null)
                    resultado[chave] = el.Value;
            }

            return resultado;
        }
    }
}
