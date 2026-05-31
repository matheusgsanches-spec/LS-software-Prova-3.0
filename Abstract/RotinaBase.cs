using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Models;

namespace Prova_lulu___Sanxis.Abstract;

public abstract class RotinaBase : IRotina
{
    private int MemoriaTotal = 100;
    private List<string> logs { get; set; }
    private int quantidadeExecucoes = 0;
    private double usoMemoria;
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public abstract void Executar();
    public abstract string ObterDescricao();


    public virtual void ExibirCabecalho()
    {
        Console.WriteLine("Cabeçalho");
    }
    public virtual void AdicionarLog(string log)
    {
        logs.Add(log);
    }
    public void qtdExec()
    {
        quantidadeExecucoes++;
        Console.WriteLine($"Qtd exec:{quantidadeExecucoes}");
    }
    public void RemoverLog()
    {
        foreach (string log in logs)
        {
            logs.Remove(log);
        }
    }
}