# CaixaEletronico
caixa eletrônico com funcionalidades de depósitos e priorização de saques. 

[![Build status](https://ci.appveyor.com/api/projects/status/wxas2xaritwo9q78/branch/master?svg=true)](https://ci.appveyor.com/project/mateusggeracino/caixaeletronico/branch/master)

```cs
 ICaixaEletronico caixaEletronico = new CaixaEletronicoProcessors();
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
```
