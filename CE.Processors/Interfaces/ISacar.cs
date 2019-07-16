using CE.Processors.Models;

namespace CE.Processors.Interfaces
{
    public interface ISacar
    {
        string RealizarSaque(ref Carteira carteira, decimal valor);
    }
}