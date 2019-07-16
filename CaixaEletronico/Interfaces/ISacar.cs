using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ISacar
    {
        string RealizarSaque(ref Carteira carteira, decimal valor);
    }
}