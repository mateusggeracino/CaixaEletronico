using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface IDepositar
    {
        void RealizarDeposito(ref Model.Carteira carteira, Notas indexNota, int quantidade);
    }
}