using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ISacar
    {
        void Saque(ref Carteira carteira, decimal valor);
    }
}