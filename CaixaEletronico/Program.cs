using CE.Processors.Business;
using CE.Processors.Interfaces;
using CE.Processors.Models;
using CE.Processors.Processors;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixaEletronico = new CaixaEletronicoProcessor(new Depositar(), new Sacar(), new Relatorio());
            var carteira = new Carteira();
            var sair = false;

            do{
                caixaEletronico.MostrarMenu();
                var opcao = caixaEletronico.PegaInput();

                switch (opcao)
                {
                    case 1:
                        caixaEletronico.RealizarDeposito(carteira);
                        break;
                    case 2:
                        caixaEletronico.RealizarSaque(carteira);
                        break;
                    case 3:
                        caixaEletronico.MostrarRelatorio(carteira);
                        break;
                    case 4:
                        sair = true;
                        break;
                }
            } while (!sair);
        }
    }
}
