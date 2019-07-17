using CE.Processors.Interfaces;
using CE.Processors.Models;
using System.Collections.Generic;
using System.Linq;

namespace CE.Processors.Business
{
    public class Depositar : IDepositar
    {
        public void RealizarDeposito(Carteira carteira, int indexNota, int quantidade, List<Notas> cedulas)
        {
            var notaAdicionada = cedulas[indexNota];
            var nota = carteira.Cedulas.Where(x => x.Valor == notaAdicionada.Valor).ToList();

            AdicionarValorCarteira(carteira, notaAdicionada, nota, quantidade);
        }

        private void AdicionarValorCarteira(Carteira carteira, Notas notaAdicionada, List<Notas> nota, int quantidade)
        {
            if (nota.Any())
                nota.First().Quantidade += quantidade;
            else
            {
                carteira.Cedulas.Add(new Notas
                {
                    Nota = notaAdicionada.Nota,
                    Valor = notaAdicionada.Valor,
                    Quantidade = quantidade
                });
            }
        }
    }
}