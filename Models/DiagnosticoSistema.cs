using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Abstract;
using Prova_lulu___Sanxis.Services;

namespace Prova_lulu___Sanxis.Models;

public class DiagnosticoSistema : RotinaBase
{
    private string Nome { get; set; }
    private string Usuario { get; set; }
    private string SistemaOperacional { get; set; }
    private DateTime DataHora { get; set; }

    public override void Executar()
    {
        try
        {
            Nome = Environment.MachineName;
            Usuario = Environment.UserName;
            SistemaOperacional = Environment.OSVersion.ToString();
            DataHora = DateTime.Now;

            Console.WriteLine($"Máquina: {Nome}");
            Console.WriteLine($"Usuário: {Usuario}");
            Console.WriteLine($"Sistema Operacional: {SistemaOperacional}");
            Console.WriteLine($"Data/Hora: {DataHora}");

            Logger.Salvar(
                "diagnostico.txt",
                $"Máquina: {Nome} | Usuário: {Usuario} | Sistema: {SistemaOperacional}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            Logger.Salvar(
                "diagnostico.txt",
                $"ERRO | {ex.Message}"
            );
        }
    }

    public override string ObterDescricao()
    {
        return "Realiza limpeza de arquivos temporários.";
    }
}