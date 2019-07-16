﻿using System.Collections.Generic;
using System.Linq;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Model;

namespace CaixaEletronico.Business
{
    public class Depositar : IDepositar
    {
        public void RealizarDeposito(ref Carteira carteira, int indexNota, int quantidade, List<Notas> cedulas)
        {
            var notaAdicionada = cedulas[indexNota];
            var nota = carteira.Cedulas.Where(x => x.Valor == notaAdicionada.Valor);

            if (nota.Any())
                nota.First().Quantidade += quantidade;
            else
            {
                carteira.Cedulas.Add(new Notas
                {
                    Nota = notaAdicionada.Nota,
                    Valor = notaAdicionada.Valor,
                    Quantidade = quantidade
                });
            }
        }
    }
}