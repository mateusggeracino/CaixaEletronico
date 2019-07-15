using CaixaEletronico.Model;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixaEletronico = new Processors.CaixaEletronico();
            var carteira = new Carteira();
            var sair = false;

            do
            {
                var opcao = caixaEletronico.MostrarMenu();

                switch (opcao)
                {
                    case 1:
                        caixaEletronico.AdicionarQuantidades(carteira, Notas.Notas10);
                        break;
                    case 2:
                        caixaEletronico.AdicionarQuantidades(carteira, Notas.Notas20);
                        break;
                    case 3:
                        caixaEletronico.AdicionarQuantidades(carteira, Notas.Notas50);
                        break;
                    case 4:
                        //Adicionar regra de saque
                        break;
                    case 5:
                        caixaEletronico.MostrarRelatorio(carteira);
                        break;
                    case 6:
                        sair = true;
                        break;
                    default:
                        break;
                }

            } while (!sair);
        }
    }
}
