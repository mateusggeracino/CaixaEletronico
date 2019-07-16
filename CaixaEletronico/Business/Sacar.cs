using System.Linq;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Sacar : ISacar
    {
        public string RealizarSaque(ref Carteira carteira, decimal valorSaque)
        {
            var carteiraOrdenada = carteira.Cedulas.OrderByDescending(x => x.Valor).ToList();
            if (valorSaque > carteira.ValorTotal) return "Aqui não tem cheque especial, otário.";

            foreach (var nota in carteiraOrdenada)
            {
                if (valorSaque == 0) break;
                if (nota.Quantidade == 0) continue;
                
                var retiraNota = (int)(valorSaque / nota.Valor);
                if (retiraNota > nota.Quantidade && nota.Quantidade != 0) retiraNota = nota.Quantidade;

                nota.Quantidade -= retiraNota;
                valorSaque -= retiraNota * nota.Valor;
            }

            if (valorSaque > 0) return "Você não tem notas suficientes.";
            return "Saque efetuado com sucesso. Você está mais pobre.";
        }
    }
}