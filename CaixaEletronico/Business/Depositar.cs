using System.Collections.Generic;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Depositar : IDepositar
    {
        public void RealizarDeposito(ref Carteira carteira, Notas indexNota, int quantidade)
        {
            carteira.Cedulas.Add(indexNota, quantidade);
        }
    }
}