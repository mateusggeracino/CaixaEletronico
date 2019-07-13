using System.Collections.Generic;
using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface IDeposito
    {
        void RealizarDeposito(List<Cedula> cedulas);
    }
}