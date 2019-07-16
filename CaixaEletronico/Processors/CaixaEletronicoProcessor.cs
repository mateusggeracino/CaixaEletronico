using System;
using System.Collections.Generic;
using System.Linq;
using CaixaEletronico.Business;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Processors
{
    public class CaixaEletronicoProcessor : ICaixaEletronico
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;
        private readonly List<Notas> _Cedulas;
        public CaixaEletronicoProcessor()
        {
            _Cedulas = Carteira.ObterListaCedulas();
            _deposito = new Depositar();
            //_saque = new Sacar();
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
            Console.WriteLine("Selecione o valor da cédula: ");
            
            for (var i = 0; i < _Cedulas.Count(); i++)
            {
                Console.WriteLine($"{i} - R$ {_Cedulas[i]}");
            }
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

            foreach(var teste in Enum.GetValues(typeof(Notas)))
            {
                Console.WriteLine(teste);
            }

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
            var indexNota = PegaInput();

            DigitarQuantidadeCeulas();
            var quantidade = PegaInput();

            _deposito.RealizarDeposito(ref carteira, (Notas)indexNota, quantidade);
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