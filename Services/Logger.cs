using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Prova_lulu___Sanxis.Services;

public static class Logger
{
    public static void Salvar(string arquivoLog, string mensagem)
    {
        string pastaLogs = "Logs";

        if (!Directory.Exists(pastaLogs))
        {
            Directory.CreateDirectory(pastaLogs);
        }

        string caminho = Path.Combine(pastaLogs, arquivoLog);

        string log =
            $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {mensagem}" +
            Environment.NewLine;

        File.AppendAllText(caminho, log);
    }

    public static void MostrarLogs()
    {
        string pastaLogs = "Logs";

        if (!Directory.Exists(pastaLogs))
        {
            Console.WriteLine("Nenhum log encontrado.");
            return;
        }

        string[] arquivos = Directory.GetFiles(pastaLogs);

        if (arquivos.Length == 0)
        {
            Console.WriteLine("Nenhum log encontrado.");
            return;
        }

        foreach (string arquivo in arquivos)
        {
            Console.WriteLine($"\n===== {Path.GetFileName(arquivo)} =====");
            Console.WriteLine(File.ReadAllText(arquivo));
        }
    }
}