using CE.Processors.Business;
using CE.Processors.Interfaces;
using CE.Processors.Models;
using System;
using System.Collections.Generic;

namespace CE.Processors.Processors
{
    public class CaixaEletronicoProcessor : ICaixaEletronico
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;
        private List<Notas> _Cedulas;

        public CaixaEletronicoProcessor()
        {
            _Cedulas = Notas.ObterNotas();
            _deposito = new Depositar();
            _saque = new Sacar();
        }

        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine(Labels.AsteriscosParaMenu);
            Console.WriteLine(Labels.AsteriscosCaixaEletronico);
            Console.WriteLine(Labels.AsteriscosParaMenu);

            Console.WriteLine(Labels.OpcaoDeposito);
            Console.WriteLine(Labels.OpcaoSaque);
            Console.WriteLine(Labels.OpcaoRelatorio);
            Console.WriteLine(Labels.OpcaoSair);
        }

        public void MostrarMenuDeposito()
        {
            Console.Clear();
            Console.WriteLine(Labels.SelecionarCedula);

            for (var index = 0; index < _Cedulas.Count; index++)
            {
                Console.WriteLine(string.Format(Labels.ApresentarNotas, index, _Cedulas[index].Nota));
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
            Console.WriteLine(Labels.AsteriscosParaMenu);
            Console.WriteLine(Labels.AsteriscosRelatorio);
            Console.WriteLine(Labels.AsteriscosParaMenu);

            foreach (var cedula in carteira.Cedulas)
            {
                var linhaRelatorio = string.Format(Labels.ValorTotalNotaRelatorio, cedula.Nota, cedula.Valor * cedula.Quantidade);
                Console.WriteLine(linhaRelatorio);
            }
            Console.WriteLine(string.Format(Labels.SaldoCarteira, carteira.ValorTotal));

            PressioneQualquerTecla();
        }

        public void DigitarQuantidadeCeulas()
        {
            Console.Clear();
            Console.WriteLine(Labels.DigiteQuantidadeNota);
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
            Console.WriteLine(Labels.DigiteValorSaque);
            var valorSaque = Convert.ToDecimal(Console.ReadLine());

            var resultado = _saque.RealizarSaque(ref carteira, valorSaque);
            Console.WriteLine(resultado);

            PressioneQualquerTecla();
        }

        private void PressioneQualquerTecla()
        {
            Console.WriteLine(Labels.PressioneParaContinuar);
            Console.ReadKey();
        }
    }
}