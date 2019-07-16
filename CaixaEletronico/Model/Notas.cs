using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.Model
{
    public class Notas
    {
        public static List<Notas> ObterNotas()
        {
            var notas = new List<Notas>
            {
                new Notas {Nota = "R$ 0,50", Valor = Convert.ToDecimal(0.5)},
                new Notas {Nota = "R$ 50,00", Valor = 50},
                new Notas {Nota = "R$ 20,00", Valor = 20},
                new Notas {Nota = "R$ 10,00", Valor = 10},
            };

            return notas.OrderBy(x => x.Valor).ToList();
        }

        public string Nota { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}