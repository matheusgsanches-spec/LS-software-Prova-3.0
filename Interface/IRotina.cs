using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_lulu___Sanxis.Models;

public interface IRotina
{
    void Executar();
    string ObterDescricao();
}