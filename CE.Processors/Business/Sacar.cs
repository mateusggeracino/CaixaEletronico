using CE.Processors.Interfaces;
using CE.Processors.Models;
using System.Collections.Generic;
using System.Linq;

namespace CE.Processors.Business
{
    public class Sacar : ISacar
    {
        public string RealizarSaque(Carteira carteira, decimal valorSaque)
        {
            var carteiraOrdenada = carteira.Cedulas.OrderByDescending(x => x.Valor).ToList();
            if (valorSaque > carteira.ValorTotal) return Labels.SemSaldo;

            RemoverDinheiroCarteira(carteiraOrdenada, ref valorSaque);

            if (valorSaque > 0) return Labels.NotasInsuficientes;
            return Labels.SaldoEfetuado;
        }

        private void RemoverDinheiroCarteira(List<Notas> carteiraOrdenada, ref decimal valorSaque)
        {
            foreach (var nota in carteiraOrdenada)
            {
                if (valorSaque == 0) break;
                if (nota.Quantidade == 0) continue;

                var retiraNota = (int)(valorSaque / nota.Valor);
                if (retiraNota > nota.Quantidade && nota.Quantidade != 0) retiraNota = nota.Quantidade;

                nota.Quantidade -= retiraNota;
                valorSaque -= retiraNota * nota.Valor;
            }
        }
    }
}