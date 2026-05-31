using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Models;
using Prova_lulu___Sanxis.Services;

namespace Prova_lulu___Sanxis.Services;

public class MenuService
{
    private readonly List<IRotina> _rotinas;

    public MenuService()
    {
        _rotinas = new List<IRotina>
        {
            new LimpezaTemp(),
            new MonitorMemoria(),
            new BackupRotina(),
            new OrganizadorArquivos(),
            new DiagnosticoSistema()
        };
    }

    public void Executar()
    {
        int opcao;

        do
        {
            Console.Clear();
            ExibirMenu();

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
                continue;
            }

            ProcessarOpcao(opcao);

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla...");
                Console.ReadKey();
            }

        } while (opcao != 0);
    }

    private void ExibirMenu()
    {
        Console.WriteLine("===== SISTEMA DE ROTINAS =====");
        Console.WriteLine("1 - Executar Limpeza");
        Console.WriteLine("2 - Monitorar Memória");
        Console.WriteLine("3 - Fazer Backup");
        Console.WriteLine("4 - Organizar Arquivos");
        Console.WriteLine("5 - Diagnóstico");
        Console.WriteLine("6 - Executar Todas");
        Console.WriteLine("7 - Mostrar Logs");
        Console.WriteLine("0 - Sair");

        Console.Write("\nEscolha uma opção: ");
    }

    private void ProcessarOpcao(int opcao)
    {
        try
        {
            switch (opcao)
            {
                case 1:
                    _rotinas[0].Executar();
                    break;

                case 2:
                    _rotinas[1].Executar();
                    break;

                case 3:
                    _rotinas[2].Executar();
                    break;

                case 4:
                    _rotinas[3].Executar();
                    break;

                case 5:
                    _rotinas[4].Executar();
                    break;

                case 6:
                    ExecutarTodas();
                    break;

                case 7:
                    Logger.MostrarLogs();
                    break;

                case 0:
                    Console.WriteLine("Encerrando...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private void ExecutarTodas()
    {
        foreach (IRotina rotina in _rotinas)
        {
            rotina.Executar();
            Console.WriteLine();
        }
    }
}