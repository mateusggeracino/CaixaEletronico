# CaixaEletronico
Caixa eletrônico com funcionalidades de depósitos e priorização de saques. 

## Branch - CaixaEletronicoGenerico
[![Build status](https://ci.appveyor.com/api/projects/status/wxas2xaritwo9q78/branch/CaixaEletronicoGenerico?svg=true)](https://ci.appveyor.com/project/mateusggeracino/caixaeletronico/branch/CaixaEletronicoGenerico)

```cs
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
```
