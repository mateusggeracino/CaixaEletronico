using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Sacar : ISacar
    {
        public void Saque(ref Carteira carteira, decimal valor)
        {
            if (valor == 0) return;

            var quantidadeNotas10 = carteira.Notas10 != 0 ? carteira.Notas10 / 10 : 0;
            var quantidadeNotas20 = carteira.Notas20 != 0 ? carteira.Notas20 / 20 : 0;
            var quantidadeNotas50 = carteira.Notas50 != 0 ? carteira.Notas50 / 50 : 0;

            while(valor != 0)
            {
                

                if (valor / 20 > 0 && quantidadeNotas20 > 0)
                {

                }

                if (valor / 10 > 0 && quantidadeNotas10 > 0)
                {

                }
            }

            var teste = valor / 50;
        }
    }
}
