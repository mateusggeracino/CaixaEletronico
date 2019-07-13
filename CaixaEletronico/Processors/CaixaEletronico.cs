using System;
using CaixaEletronico.Business;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Processors
{
    public class CaixaEletronico : ICaixaEletronico
    {
        private readonly IDeposito _deposito;
        private readonly ISaque _saque;

        public CaixaEletronico()
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

            Console.WriteLine($"10 Reais - {carteira.Notas10 * 10}");
            Console.WriteLine($"20 Reais - {carteira.Notas20 * 20}");
            Console.WriteLine($"50 Reais - {carteira.Notas50 * 50}");
            Console.ReadKey();
        }

        public int AdicionarQuantidades()
        {
            Console.Clear();
            Console.WriteLine($"Digite a quantidade de cédulas:");
            var quantidade = Console.ReadLine();
            Console.Clear();

            return Convert.ToInt32(quantidade);
        }
    }
}