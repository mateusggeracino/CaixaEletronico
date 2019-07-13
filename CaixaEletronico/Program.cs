using System;
using System.Collections.Generic;
using CaixaEletronico.Model;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixaEletronico = new Processors.CaixaEletronico();
            var carteira = new Carteira();
            int input;
            var sair = false;
            do
            {

                var opcao = caixaEletronico.MostrarMenu();

                switch (opcao)
                {
                    case 1:
                        input = caixaEletronico.AdicionarQuantidades();
                        carteira.Notas10 += Convert.ToInt32(input);
                        break;
                    case 2:
                        input = caixaEletronico.AdicionarQuantidades();
                        carteira.Notas20 += Convert.ToInt32(input);
                        break;
                    case 3:
                        input = caixaEletronico.AdicionarQuantidades();
                        carteira.Notas50 += Convert.ToInt32(input);
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
