using System;
using System.IO;

namespace ModBabel.Core
{
    // Ponto único de log do ModBabel. Duas camadas, sempre transparentes:
    // 1) UnityEngine.Debug.Log/LogError - sempre acontece, é o
    //    comportamento padrão de qualquer mod do CS1, vai parar no
    //    output_log.txt do próprio jogo (não é nada escondido).
    // 2) Arquivo próprio (ModBabel.log, na pasta do mod) - só grava se
    //    o jogador ligar "Habilitar log detalhado" na tela de opções
    //    do ModBabel (ver LogPreference.cs). Existe pra facilitar
    //    reportar bugs sem precisar caçar o output_log.txt inteiro do
    //    jogo, que tem log de todos os outros mods misturado.
    public static class Logger
    {
        private const string NomeArquivo = "ModBabel.log";
        private static readonly object Trava = new object();

        public static void Log(string mensagem)
        {
            UnityEngine.Debug.Log($"[ModBabel] {mensagem}");
            EscreverNoArquivo("INFO", mensagem);
        }

        public static void LogErro(string mensagem)
        {
            UnityEngine.Debug.LogError($"[ModBabel] {mensagem}");
            EscreverNoArquivo("ERRO", mensagem);
        }

        private static void EscreverNoArquivo(string nivel, string mensagem)
        {
            if (!LogPreference.Habilitado()) return;

            var pastaMod = ModFolder.Caminho();
            if (string.IsNullOrEmpty(pastaMod)) return;

            var linha = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{nivel}] {mensagem}{Environment.NewLine}";

            lock (Trava)
            {
                try
                {
                    File.AppendAllText(Path.Combine(pastaMod, NomeArquivo), linha);
                }
                catch
                {
                    // log nunca pode ser motivo de quebrar o mod
                }
            }
        }
    }
}
