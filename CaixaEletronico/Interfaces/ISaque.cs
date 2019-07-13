using System.Collections.Generic;
using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ISaque
    {
        void RealizarSaque(List<Cedula> cedula, List<Cedula> saldoAtual);
    }
}