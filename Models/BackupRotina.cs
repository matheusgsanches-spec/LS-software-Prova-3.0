using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Abstract;
using Prova_lulu___Sanxis.Services;
using System.Diagnostics;

namespace Prova_lulu___Sanxis.Models;

public class BackupRotina : RotinaBase
{
    public override void Executar()
    {
        Stopwatch cronometro = Stopwatch.StartNew();
        try
        {
            Console.Write("Informe a pasta de origem: ");
            string origem = Console.ReadLine()!;

            Console.Write("Informe a pasta de destino: ");
            string destino = Console.ReadLine()!;

            if (!Directory.Exists(origem))
            {
                Console.WriteLine("Pasta de origem não encontrada.");

                Logger.Salvar(
                    "backup.txt",
                    $"ERRO | Origem não encontrada: {origem}"
                );

                return;
            }

            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }

            int arquivosCopiados = 0;

            foreach (string arquivo in Directory.GetFiles(origem))
            {
                string nomeArquivo = Path.GetFileName(arquivo);

                File.Copy(
                    arquivo,
                    Path.Combine(destino, nomeArquivo),
                    true
                );

                arquivosCopiados++;
            }

            Console.WriteLine($"Backup concluído!");
            Console.WriteLine($"Arquivos copiados: {arquivosCopiados}");

            cronometro.Stop();

            Logger.Salvar(
            "backup.txt",
            $"Usuário: {Environment.UserName} | Origem: {origem} | Destino: {destino} | Arquivos: {arquivosCopiados} | Tempo: {cronometro.ElapsedMilliseconds} ms"
        );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            Logger.Salvar(
                "backup.txt",
                $"ERRO | {ex.Message}"
            );
        }
    }

    public override string ObterDescricao()
    {
        return "Realiza limpeza de arquivos temporários.";
    }
}