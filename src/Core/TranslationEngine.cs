using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

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
            var pastaMod = ModFolder.Caminho();
            if (string.IsNullOrEmpty(pastaMod))
                return new[] { "en" };

            // Idiomas conhecidos = união de todos os arquivos .xml
            // encontrados em qualquer pasta Translations/[modulo]/
            var pastaBase = Path.Combine(pastaMod, "Translations");

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

            var pastaMod = ModFolder.Caminho();
            if (string.IsNullOrEmpty(pastaMod))
                return resultado; // sem pasta resolvida = tudo cai no fallback

            var caminho = Path.Combine(Path.Combine(Path.Combine(
                pastaMod, "Translations"), moduloId), idioma + ".xml");

            if (!File.Exists(caminho))
                return resultado; // sem arquivo = tudo cai no fallback (texto original)

            // XmlDocument (DOM clássico) em vez de XDocument/Linq-to-XML:
            // o build contra net35 chamava XmlReaderSettings
            // .MaxCharactersFromEntities, membro que não existe no Mono
            // antigo empacotado com o CS1 - MissingMethodException visto
            // ao testar no jogo (2026-07-23). XmlDocument não tem essa
            // dependência e é compatível com o Mono do jogo.
            var doc = new XmlDocument();
            doc.Load(caminho);

            var nos = doc.SelectNodes("//String");
            foreach (XmlNode no in nos)
            {
                var chaveAttr = no.Attributes?["key"];
                if (chaveAttr != null)
                    resultado[chaveAttr.Value] = no.InnerText;
            }

            return resultado;
        }
    }
}
