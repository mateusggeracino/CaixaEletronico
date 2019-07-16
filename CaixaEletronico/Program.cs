using CE.Processors.Interfaces;
using CE.Processors.Models;
using CE.Processors.Processors;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            ICaixaEletronico caixaEletronico = new CaixaEletronicoProcessor();
            var carteira = new Carteira();
            var sair = false;

            do{
                caixaEletronico.MostrarMenu();
                var opcao = caixaEletronico.PegaInput();

                switch (opcao)
                {
                    case 1:
                        caixaEletronico.RealizarDeposito(ref carteira);
                        break;
                    case 2:
                        caixaEletronico.RealizarSaque(ref carteira);
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
