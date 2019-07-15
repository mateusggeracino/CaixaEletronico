using CaixaEletronico.Business;
using CaixaEletronico.Model;
using Xunit;

namespace CaixaEletronico.Tests
{
    public class SacarTests
    {
        [Fact]
        public void RealizarSaqueSucesso()
        {
            var carteira = new Carteira
            {
                Notas50 = 250,
                Notas10 = 50
            };
            var saque = new Sacar();

            var result = saque.Saque(ref carteira, 210);

            Assert.True(carteira.Notas50 == 50 || carteira.Notas10 == 40);
        }

        [Fact]
        public void RealizarSaqueFalha()
        {
            var carteira = new Carteira
            {
                Notas50 = 250,
                Notas10 = 50
            };
            var saque = new Sacar();

            var result = saque.Saque(ref carteira, 210);

            Assert.False(carteira.Notas50 != 50 || carteira.Notas10 != 40);
        }
    }
}