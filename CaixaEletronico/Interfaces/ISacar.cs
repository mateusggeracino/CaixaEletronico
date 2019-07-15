using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ISacar
    {
        string Saque(ref Carteira carteira, decimal valor);

        string RealizarSaque(ref Carteira carteira, decimal valorSaque);
    }
}