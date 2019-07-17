using System;
using CE.Processors.Interfaces;
using CE.Processors.Models;

namespace CE.Processors.Business
{
    public class Relatorio : IRelatorio
    {
        public void ObterRelatorio(Carteira carteira)
        {
            foreach (var cedula in carteira.Cedulas)
            {
                var linhaRelatorio = string.Format(Labels.ValorTotalNotaRelatorio, cedula.Nota, cedula.Valor * cedula.Quantidade);
                Console.WriteLine(linhaRelatorio);
            }
            Console.WriteLine(Labels.SaldoCarteira, carteira.ValorTotal);
        }
    }
}