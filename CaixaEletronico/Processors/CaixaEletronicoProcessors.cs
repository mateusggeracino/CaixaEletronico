using System;
using CaixaEletronico.Business;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Processors
{
    public class CaixaEletronicoProcessors : ICaixaEletronico
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;

        public CaixaEletronicoProcessors()
        {
            _deposito = new Depositar();
            _saque = new Sacar();
        }

        public int MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("-------------CARREGAR NOTAS ------------");
            Console.WriteLine("********************************************");
            Console.WriteLine("1 - 10");
            Console.WriteLine("2 - 20");
            Console.WriteLine("3 - 50");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Relatorio");
            Console.WriteLine("6 - Sair");
            var opcao = Console.ReadLine();

            return Convert.ToInt32(opcao);
        }

        public void MostrarRelatorio(Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine("************RELATÓRIO*************");

            Console.WriteLine($"10 Reais - {carteira.Notas10}");
            Console.WriteLine($"20 Reais - {carteira.Notas20}");
            Console.WriteLine($"50 Reais - {carteira.Notas50}");
            Console.ReadKey();
        }

        public int AdicionarQuantidades(Carteira carteira, Notas nota)
        {
            Console.Clear();
            Console.WriteLine($"Digite a quantidade de cédulas:");
            var quantidade = Convert.ToInt32(Console.ReadLine());

            switch (nota)
            {
                case Notas.Notas10:
                    _deposito.DepositoNota10(ref carteira, quantidade);
                    break;
                case Notas.Notas20:
                    _deposito.DepositoNota20(ref carteira, quantidade);
                    break;
                case Notas.Notas50:
                    _deposito.DepositoNota50(ref carteira, quantidade);
                    break;
            }

            Console.Clear();

            return Convert.ToInt32(quantidade);
        }

        public void RealizarSaque(ref Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine($"Digite o valor para saque:");
            var valorSaque = Convert.ToDecimal(Console.ReadLine());

            var resultado = _saque.Saque(ref carteira, valorSaque);
            Console.WriteLine(resultado);
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
        }
    }
}