using CaixaEletronico.Model;

namespace CaixaEletronico.Interfaces
{
    public interface ICaixaEletronico
    {
        int MostrarMenu();
        void MostrarRelatorio(Carteira quantidadeNotas);
        int AdicionarQuantidades();
    }
}