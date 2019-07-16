using System.Collections.Generic;
using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface IDepositar
    {
        void RealizarDeposito(ref Model.Carteira carteira, int indexNota, int quantidade, List<Notas> cedulas);
    }
}