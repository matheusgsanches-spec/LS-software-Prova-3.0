using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova_lulu___Sanxis.Abstract;
using Prova_lulu___Sanxis.Services;

namespace Prova_lulu___Sanxis.Models;

public class MonitorMemoria : RotinaBase
{
    private const double LIMITE_MB = 100;

    public override void Executar()
    {
        try
        {
            double memoriaMB = GC.GetTotalMemory(false) / 1024.0 / 1024.0;

            Console.WriteLine($"Uso de memória: {memoriaMB:F2} MB");

            string status;

            if (memoriaMB > LIMITE_MB)
            {
                Console.WriteLine("⚠ ALERTA: Uso de memória acima do limite!");
                status = "ALERTA";
            }
            else
            {
                Console.WriteLine("✓ Uso de memória normal.");
                status = "NORMAL";
            }

            Logger.Salvar(
                "monitorMemoria.txt",
                $"Usuário: {Environment.UserName} | Memória: {memoriaMB:F2} MB | Status: {status}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            Logger.Salvar(
                "monitorMemoria.txt",
                $"ERRO | Usuário: {Environment.UserName} | Mensagem: {ex.Message}"
            );
        }
    }
    public override string ObterDescricao()
    {
        return "Realiza limpeza de arquivos temporários.";
    }
}