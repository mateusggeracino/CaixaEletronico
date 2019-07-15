using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ICaixaEletronico
    {
        int MostrarMenu();
        void MostrarRelatorio(Carteira carteira);
        int AdicionarQuantidades(Carteira carteira, Notas nota);
    }
}