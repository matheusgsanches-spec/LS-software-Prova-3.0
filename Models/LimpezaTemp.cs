using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Abstract;
using Prova_lulu___Sanxis.Services;

namespace Prova_lulu___Sanxis.Models;

public class LimpezaTemp : RotinaBase
{
    public override void Executar()
    {
        string pastaTemp = Path.GetTempPath();
        int arquivosRemovidos = 0;

        Console.WriteLine($"Pasta Temp: {pastaTemp}");

        try
        {
            foreach (string arquivo in Directory.GetFiles(pastaTemp))
            {
                File.Delete(arquivo);
                arquivosRemovidos++;
            }

            Console.WriteLine("Limpeza concluída!");
            Console.WriteLine($"Arquivos removidos: {arquivosRemovidos}");

            Logger.Salvar(
                "limpezaTemp.txt",
                $"Usuário: {Environment.UserName} | Arquivos removidos: {arquivosRemovidos}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            Logger.Salvar(
                "limpezaTemp.txt",
                $"ERRO | Usuário: {Environment.UserName} | Mensagem: {ex.Message}"
            );
        }
    }
    public override string ObterDescricao()
    {
        return "Realiza limpeza de arquivos temporários.";
    }
}