using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface IDepositar
    {
        void DepositoNota10(ref Carteira carteira, int quantidadeCedulas);
        void DepositoNota20(ref Carteira carteira, int quantidadeCedulas);
        void DepositoNota50(ref Carteira carteira, int quantidadeCedulas);
    }
}