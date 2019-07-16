using CE.Processors.Business;
using CE.Processors.Models;
using System.Linq;
using Xunit;

namespace CE.Processors.Tests
{
    public class SacarTests
    {
        [Fact]
        public void SacarSucesso()
        {
            //Arrange
            var saque = new Sacar();
            var carteira = new Carteira { Cedulas = Notas.ObterNotas() };
            carteira.Cedulas.ForEach(x => x.Quantidade = 1);
            var valorSaque = 120;

            //Act
            saque.RealizarSaque(ref carteira, valorSaque);
            var nota100 = carteira.Cedulas.Where(x => x.Valor == 100).First();
            var nota20 = carteira.Cedulas.Where(x => x.Valor == 20).First();

            //Assert
            Assert.True(nota100.Quantidade == 0);
            Assert.True(nota20.Quantidade == 0);
        }

        [Fact]
        public void SacarDiversasNotasSucesso()
        {
            //Arrange
            var saque = new Sacar();
            var carteira = new Carteira { Cedulas = Notas.ObterNotas() };
            carteira.Cedulas.ForEach(x => x.Quantidade = 2);
            var valorSaque = 80;

            //Act
            saque.RealizarSaque(ref carteira, valorSaque);
            var nota50 = carteira.Cedulas.Where(x => x.Valor == 50).First();
            var nota20 = carteira.Cedulas.Where(x => x.Valor == 20).First();
            var nota10 = carteira.Cedulas.Where(x => x.Valor == 10).First();

            //Assert
            Assert.True(nota50.Quantidade == 1 && nota20.Quantidade == 1 && nota10.Quantidade == 1);
        }

        [Fact]
        public void TesteSucesso()
        {
            //Arrange
            var saque = new Sacar();
            var carteira = new Carteira { Cedulas = Notas.ObterNotas() };
            carteira.Cedulas.Where(x => x.Valor == 50).First().Quantidade = 1;
            var valorSaque = 20;

            //Act
            var retorno = saque.RealizarSaque(ref carteira, valorSaque);

            //Assert
            Assert.Equal("Você não tem notas suficientes.", retorno);
        }
    }
}
