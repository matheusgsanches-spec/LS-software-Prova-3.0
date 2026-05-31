using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Abstract;
using Prova_lulu___Sanxis.Services;

namespace Prova_lulu___Sanxis.Models;

public class OrganizadorArquivos : RotinaBase
{
    public override void Executar()
    {
        try
        {
            Console.Write("Informe a pasta para organizar: ");
            string pasta = Console.ReadLine()!;

            if (!Directory.Exists(pasta))
            {
                Console.WriteLine("Pasta não encontrada.");

                Logger.Salvar(
                    "organizador.txt",
                    $"ERRO | Pasta não encontrada: {pasta}"
                );

                return;
            }

            string pastaImagens = Path.Combine(pasta, "Imagens");
            string pastaVideos = Path.Combine(pasta, "Videos");
            string pastaDocumentos = Path.Combine(pasta, "Documentos");

            Directory.CreateDirectory(pastaImagens);
            Directory.CreateDirectory(pastaVideos);
            Directory.CreateDirectory(pastaDocumentos);

            int imagens = 0;
            int videos = 0;
            int documentos = 0;

            foreach (string arquivo in Directory.GetFiles(pasta))
            {
                string extensao = Path.GetExtension(arquivo).ToLower();

                if (EhImagem(extensao))
                {
                    File.Move(
                        arquivo,
                        Path.Combine(pastaImagens, Path.GetFileName(arquivo)),
                        true
                    );

                    imagens++;
                }
                else if (EhVideo(extensao))
                {
                    File.Move(
                        arquivo,
                        Path.Combine(pastaVideos, Path.GetFileName(arquivo)),
                        true
                    );

                    videos++;
                }
                else if (EhDocumento(extensao))
                {
                    File.Move(
                        arquivo,
                        Path.Combine(pastaDocumentos, Path.GetFileName(arquivo)),
                        true
                    );

                    documentos++;
                }
            }

            Console.WriteLine("Organização concluída!");
            Console.WriteLine($"Imagens: {imagens}");
            Console.WriteLine($"Vídeos: {videos}");
            Console.WriteLine($"Documentos: {documentos}");

            Logger.Salvar(
                "organizador.txt",
                $"Usuário: {Environment.UserName} | Imagens: {imagens} | Vídeos: {videos} | Documentos: {documentos}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            Logger.Salvar(
                "organizador.txt",
                $"ERRO | {ex.Message}"
            );
        }
    }

    private bool EhImagem(string extensao)
    {
        return extensao == ".jpg" ||
               extensao == ".jpeg" ||
               extensao == ".png" ||
               extensao == ".gif";
    }

    private bool EhVideo(string extensao)
    {
        return extensao == ".mp4" ||
               extensao == ".avi" ||
               extensao == ".mov" ||
               extensao == ".mkv";
    }

    private bool EhDocumento(string extensao)
    {
        return extensao == ".pdf" ||
               extensao == ".doc" ||
               extensao == ".docx" ||
               extensao == ".txt";
    }
    public override string ObterDescricao()
    {
        return "Realiza limpeza de arquivos temporários.";
    }
}