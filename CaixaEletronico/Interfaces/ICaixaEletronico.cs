using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ICaixaEletronico
    {
        int MostrarMenu();
        void MostrarRelatorio(Carteira carteira);
        int Depositar(Carteira carteira, Notas nota);
        void RealizarSaque(ref Carteira carteira);
    }
}