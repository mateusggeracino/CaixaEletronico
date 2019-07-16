using System;
using CaixaEletronico.Business;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Processors
{
    public class CaixaEletronicoProcessor : ICaixaEletronico
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;

        public CaixaEletronicoProcessor()
        {
            _deposito = new Depositar();
            _saque = new Sacar();
        }

        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("********************************************");
            Console.WriteLine("-------------CAIXA ELETRÔNICO------------");
            Console.WriteLine("********************************************");
            Console.WriteLine("1 - Deposito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Relatorio");
            Console.WriteLine("4 - Sair");
        }

        public void MostrarMenuDeposito()
        {
            Console.Clear();
            Console.WriteLine("Seleciona a célula a depositar: ");
            Console.WriteLine("1 - R$ 10,00");
            Console.WriteLine("2 - R$ 20,00");
            Console.WriteLine("3 - R$ 50,00");
        }
        
        public int PegaInput()
        {
            var opcao = Console.ReadLine();
            return Convert.ToInt32(opcao);
        }

        public void MostrarRelatorio(Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine("************RELATÓRIO*************");

            Console.WriteLine($"R$ 10,00  - {carteira.Notas10}");
            Console.WriteLine($"R$ 20,00  - {carteira.Notas20}");
            Console.WriteLine($"R$ 50,00  - {carteira.Notas50}");

            Console.WriteLine("\nDigite qualquer tecla para continuar");
            Console.ReadKey();
        }

        public void DigitarQuantidadeCeulas()
        {
            Console.Clear();
            Console.WriteLine("Digite a quantidade de cédulas:");
        }

        public void RealizarDeposito(ref Carteira carteira)
        {
            MostrarMenuDeposito();
            var opcao = PegaInput();

            DigitarQuantidadeCeulas();
            var quantidade = PegaInput();

            switch (opcao)
            {
                case 1:
                    _deposito.DepositoNota10(ref carteira, quantidade);
                    break;
                case 2:
                    _deposito.DepositoNota20(ref carteira, quantidade);
                    break;
                case 3:
                    _deposito.DepositoNota50(ref carteira, quantidade);
                    break;
            }
        }

        public void RealizarSaque(ref Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine("Digite o valor para saque:");
            var valorSaque = Convert.ToDecimal(Console.ReadLine());

            var resultado = _saque.Saque(ref carteira, valorSaque);
            Console.WriteLine(resultado);
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
        }
    }
}