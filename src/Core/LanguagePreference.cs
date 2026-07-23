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
            // de outros mods. Causava uma travada perceptível e nem
            // resolvia o problema mesmo assim.
            //
            // SOLUÇÃO ATUAL (2026-07-24): em vez de tentar forçar o jogo
            // a reconstruir a UI de cada mod, o ModBabel mantém seu
            // próprio registro de todo componente já traduzido (ver
            // TranslatedComponentRegistry.cs), sempre junto com o texto
            // ORIGINAL em inglês. Trocar o idioma aqui re-traduz cada um
            // deles ao vivo, direto no componente já existente na tela -
            // não depende do jogo reconstruir nada, funciona mesmo com a
            // aba fechada/escondida.
            //
            // Cobertura desta primeira versão: módulos que usam
            // UiTreeTranslator (Play It!, Better Budget, Check Road
            // Access for Growables, Commuter Destination, Bulldoze It!).
            // AINDA precisam reiniciar o jogo pra aplicar: Rainfall
            // (traduz um dicionário antes da criação da UI, não tem
            // componente registrado depois) e os módulos baseados em
            // ModsCommon/AlgernonCommons (Advanced Stop Selection,
            // Building Spawn Points, 81 Tiles 2, ACME) - esses
            // frameworks têm o próprio sistema de idioma, que não sabe
            // que o ModBabel mudou algo por baixo.
            TranslatedComponentRegistry.RetraduzirTudo();
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
