using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.Model
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