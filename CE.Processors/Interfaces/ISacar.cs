using CE.Processors.Models;

namespace CE.Processors.Interfaces
{
    public interface ISacar
    {
        string RealizarSaque(Carteira carteira, decimal valor);
    }
}