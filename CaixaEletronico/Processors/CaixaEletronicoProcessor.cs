using CaixaEletronico.Business;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Processors
{
    public class CaixaEletronicoProcessor : ICaixaEletronico
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;
        private readonly List<Notas> _Cedulas;
        public CaixaEletronicoProcessor()
        {
            _Cedulas = Notas.ObterNotas();
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
            Console.WriteLine("Selecione o valor da cédula: ");

            for (var index = 0; index < _Cedulas.Count; index++)
            {
                Console.WriteLine($"{index} - {_Cedulas[index].Nota}");
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

            foreach (var cedula in carteira.Cedulas)
            {
                Console.WriteLine($"Valor Total de {cedula.Nota} - R$ {cedula.Valor * cedula.Quantidade}");
            }
            Console.WriteLine($"Saldo total - R$ {carteira.ValorTotal}");

            PressioneQualquerTecla();
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

            _deposito.RealizarDeposito(ref carteira, indexNota, quantidade, _Cedulas);
        }

        public void RealizarSaque(ref Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine("Digite o valor para saque:");
            var valorSaque = Convert.ToDecimal(Console.ReadLine());

            var resultado = _saque.RealizarSaque(ref carteira, valorSaque);
            Console.WriteLine(resultado);
            
            PressioneQualquerTecla();
        }

        private void PressioneQualquerTecla()
        {
            Console.WriteLine("\nPressione enter para continuar");
            Console.ReadKey();
        }
    }
}