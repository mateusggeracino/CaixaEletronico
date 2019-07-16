using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.Model
{
    public class Carteira
    {
        public Carteira()
        {
            Cedulas = new Dictionary<Notas, int>();
        }

        public Dictionary<Notas, int> Cedulas { get; set; }
        public decimal ValorTotal { get; set; }

        public static List<Notas> ObterListaCedulas()
        {
            return Enum.GetValues(typeof(Notas)).Cast<Notas>().ToList();
        }
    }
}