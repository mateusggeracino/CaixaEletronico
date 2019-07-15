using System;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Sacar : ISacar
    {
        public string Saque(ref Carteira carteira, decimal valorSaque)
        {
            var saldoCarteira = SaldoCarteira(carteira);
            if ((valorSaque > saldoCarteira) || valorSaque == 0) return "Saldo inválido";
           
            return RealizarSaque(ref carteira, valorSaque);
        }

        private decimal SaldoCarteira(Carteira carteira) =>
            carteira.Notas10 + carteira.Notas20 + carteira.Notas50 + carteira.Notas100;

        public string RealizarSaque(ref Carteira carteira, decimal valorSaque)
        {
            var quantidadeNotas10 = carteira.Notas10 != 0 ? carteira.Notas10 / 10 : 0;
            var quantidadeNotas20 = carteira.Notas20 != 0 ? carteira.Notas20 / 20 : 0;
            var quantidadeNotas50 = carteira.Notas50 != 0 ? carteira.Notas50 / 50 : 0;

            while (valorSaque != 0)
            {
                RemoverValorNota50(ref carteira, ref valorSaque, ref quantidadeNotas50);
                RemoverValorNota20(ref carteira, ref valorSaque, ref quantidadeNotas20);
                RemoverValorNota10(ref carteira, ref valorSaque, ref quantidadeNotas10);
            }

            return "Saque realizado.";
        }

        private void RemoverValorNota10(ref Carteira carteira, ref decimal valorSaque, ref int quantidadeNotas10)
        {
            if (quantidadeNotas10 > 0 && valorSaque >= 10)
            {
                var cedulasNecessarias = (int)(valorSaque / 10);
                if (cedulasNecessarias > quantidadeNotas10)
                {
                    cedulasNecessarias = quantidadeNotas10;
                }

                carteira.Notas10 -= cedulasNecessarias * 10;
                valorSaque -= cedulasNecessarias * 10;
            }
        }

        private void RemoverValorNota20(ref Carteira carteira, ref decimal valorSaque, ref int quantidadeNotas20)
        {
            if (quantidadeNotas20 > 0 && valorSaque >= 20)
            {
                var cedulasNecessarias = (int)(valorSaque / 20);

                if (cedulasNecessarias > quantidadeNotas20)
                {
                    cedulasNecessarias = quantidadeNotas20;
                }

                carteira.Notas20 -= cedulasNecessarias * 20;
                valorSaque -= cedulasNecessarias * 20;
            }
        }

        private void RemoverValorNota50(ref Carteira carteira, ref decimal valorSaque, ref int quantidadeNotas50)
        {
            if (quantidadeNotas50 > 0 && valorSaque >= 50)
            {
                var cedulasNecessarias = (int)(valorSaque / 50);

                if (cedulasNecessarias > quantidadeNotas50)
                {
                    cedulasNecessarias = quantidadeNotas50;
                }

                carteira.Notas50 -= cedulasNecessarias * 50;
                valorSaque -= cedulasNecessarias * 50;
            }
        }
    }
}
