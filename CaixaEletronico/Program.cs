using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;
using CaixaEletronico.Processors;

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
                var opcao = caixaEletronico.MostrarMenu();
                switch (opcao)
                {
                    case 1:
                        caixaEletronico.Depositar(carteira, Notas.Notas10);
                        break;
                    case 2:
                        caixaEletronico.Depositar(carteira, Notas.Notas20);
                        break;
                    case 3:
                        caixaEletronico.Depositar(carteira, Notas.Notas50);
                        break;
                    case 4:
                        caixaEletronico.RealizarSaque(ref carteira);
                        break;
                    case 5:
                        caixaEletronico.MostrarRelatorio(carteira);
                        break;
                    case 6:
                        sair = true;
                        break;
                }

            } while (!sair);
        }
    }
}
