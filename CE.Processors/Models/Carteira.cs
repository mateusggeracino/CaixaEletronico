using System.Collections.Generic;
using System.Linq;

namespace CE.Processors.Models
{
    public class Carteira
    {
        public Carteira()
        {
            Cedulas = new List<Notas>();
        }
        public List<Notas> Cedulas { get; set; }

        public decimal ValorTotal
        {
            get { return Cedulas.Sum(x => (x.Valor * x.Quantidade)); }
        }
    }
}