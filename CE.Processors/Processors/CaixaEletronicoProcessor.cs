using CE.Processors.Business;
using CE.Processors.Interfaces;
using CE.Processors.Models;
using System;
using System.Collections.Generic;

namespace CE.Processors.Processors
{
    public class CaixaEletronicoProcessor
    {
        private readonly IDepositar _deposito;
        private readonly ISacar _saque;
        private readonly IRelatorio _relatorio;
        private List<Notas> _Cedulas;
        
        public CaixaEletronicoProcessor(IDepositar depositar, ISacar sacar, IRelatorio relatorio)
        {
            _Cedulas = Notas.ObterNotas();
            _deposito = depositar;
            _saque = sacar;
            _relatorio = relatorio;
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

            _relatorio.ObterRelatorio(carteira);
            PressioneQualquerTecla();
        }

        public void DigitarQuantidadeCeulas()
        {
            Console.Clear();
            Console.WriteLine(Labels.DigiteQuantidadeNota);
        }

        public void RealizarDeposito(Carteira carteira)
        {
            MostrarMenuDeposito();
            var indexNota = PegaInput();

            DigitarQuantidadeCeulas();
            var quantidade = PegaInput();

            _deposito.RealizarDeposito(carteira, indexNota, quantidade, _Cedulas);
        }

        public void RealizarSaque(Carteira carteira)
        {
            Console.Clear();
            Console.WriteLine(Labels.DigiteValorSaque);
            var valorSaque = Convert.ToDecimal(Console.ReadLine());

            var resultado = _saque.RealizarSaque(carteira, valorSaque);
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