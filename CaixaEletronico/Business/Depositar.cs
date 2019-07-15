using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Depositar : IDepositar
    {
        public void DepositoNota10(ref Carteira carteira, int quantidadeCedulas) =>
            carteira.Notas10 = quantidadeCedulas * 10;
        

        public void DepositoNota20(ref Carteira carteira, int quantidadeCedulas) =>
            carteira.Notas20 = quantidadeCedulas * 20;

        public void DepositoNota50(ref Carteira carteira, int quantidadeCedulas) =>
            carteira.Notas50 = quantidadeCedulas * 50;
    }
}
