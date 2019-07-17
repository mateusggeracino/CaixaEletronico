using CE.Processors.Models;
using System.Collections.Generic;

namespace CE.Processors.Interfaces
{
    public interface IDepositar
    {
        void RealizarDeposito(Carteira carteira, int indexNota, int quantidade, List<Notas> cedulas);
    }
}