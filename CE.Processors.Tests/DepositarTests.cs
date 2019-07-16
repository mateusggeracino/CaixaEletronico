using CE.Processors.Business;
using CE.Processors.Models;
using System.Linq;
using Xunit;

namespace CE.Processors.Tests
{
    public class DepositarTests
    {
        [Fact]
        public void DepositoSucesso()
        {
            //Arrange
            var notasDisponiveis = Notas.ObterNotas();
            if (!notasDisponiveis.Any())
            {
                Assert.False(false);
            }

            var notaSelecionada = notasDisponiveis.First();
            var carteira = new Carteira();
            var deposito = new Depositar();
            int posicaoNota = 0, quantidade = 5;

            //Act
            deposito.RealizarDeposito(ref carteira, posicaoNota, quantidade, notasDisponiveis);

            //Assert
            Assert.True(carteira.ValorTotal == (notaSelecionada.Valor * quantidade));
        }

        [Theory]
        [InlineData(50, 2)]
        [InlineData(10, 10)]
        [InlineData(20, 5)]
        public void DepositoVariadoSucesso(int valor, int quantidade)
        {
            //Arrange
            var notasDisponiveis = Notas.ObterNotas();
            if (!notasDisponiveis.Any()) Assert.False(false);

            var posicaoNota = notasDisponiveis.IndexOf(notasDisponiveis.Where(x => x.Valor == valor).First());
            var notaSelecionada = notasDisponiveis.Where(x => x.Valor == valor).First();
            var carteira = new Carteira();
            var deposito = new Depositar();

            //Act
            deposito.RealizarDeposito(ref carteira, posicaoNota, quantidade, notasDisponiveis);

            //Assert
            Assert.True(carteira.ValorTotal == (notaSelecionada.Valor * quantidade));
        }

        [Fact]
        public void DepositoFalha()
        {
            //Arrange
            var notasDisponiveis = Notas.ObterNotas();
            if (!notasDisponiveis.Any())
            {
                Assert.False(false);
            }

            var notaSelecionada = notasDisponiveis.First();
            var carteira = new Carteira();
            var deposito = new Depositar();
            int posicaoNota = 0, quantidade = 5;

            //Act
            deposito.RealizarDeposito(ref carteira, posicaoNota, quantidade, notasDisponiveis);

            //Assert
            Assert.False(carteira.ValorTotal != (notaSelecionada.Valor * quantidade));
        }

        [Theory]
        [InlineData(50, 2)]
        [InlineData(10, 10)]
        [InlineData(20, 5)]
        public void DepositoVariadoFalha(int valor, int quantidade)
        {
            //Arrange
            var notasDisponiveis = Notas.ObterNotas();
            if (!notasDisponiveis.Any()) Assert.False(false);

            var posicaoNota = notasDisponiveis.IndexOf(notasDisponiveis.Where(x => x.Valor == valor).First());
            var notaSelecionada = notasDisponiveis.Where(x => x.Valor == valor).First();
            var carteira = new Carteira();
            var deposito = new Depositar();

            //Act
            deposito.RealizarDeposito(ref carteira, posicaoNota, quantidade, notasDisponiveis);

            //Assert
            Assert.False(carteira.ValorTotal != (notaSelecionada.Valor * quantidade));
        }
    }
}