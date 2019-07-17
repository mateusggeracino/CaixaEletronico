# CaixaEletronico
Caixa eletrônico com funcionalidades de depósitos e priorização de saques. 


[![Build status](https://ci.appveyor.com/api/projects/status/wxas2xaritwo9q78/branch/master?svg=true)](https://ci.appveyor.com/project/mateusggeracino/caixaeletronico/branch/master)


```cs
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
```
