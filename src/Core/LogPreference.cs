using System.IO;

namespace ModBabel.Core
{
    // Lê/salva se o jogador quer o log detalhado do ModBabel gravado em
    // arquivo (ModBabel.log, na pasta do mod). Desligado por padrão -
    // não queremos criar um arquivo crescendo sem o jogador saber; só
    // grava quando ele liga explicitamente (ex: pra reportar um bug).
    public static class LogPreference
    {
        private const bool PadraoHabilitado = false;
        private static bool? _habilitadoEmCache;

        public static bool Habilitado()
        {
            if (_habilitadoEmCache.HasValue)
                return _habilitadoEmCache.Value;

            var caminho = CaminhoConfig();
            _habilitadoEmCache = caminho != null && File.Exists(caminho)
                ? File.ReadAllText(caminho).Trim() == "1"
                : PadraoHabilitado;

            return _habilitadoEmCache.Value;
        }

        public static void Definir(bool habilitado)
        {
            _habilitadoEmCache = habilitado;

            var caminho = CaminhoConfig();
            if (caminho != null)
                File.WriteAllText(caminho, habilitado ? "1" : "0");
        }

        private static string CaminhoConfig()
        {
            var pastaMod = ModFolder.Caminho();
            return string.IsNullOrEmpty(pastaMod)
                ? null
                : Path.Combine(pastaMod, "modbabel_log.cfg");
        }
    }
}
