using CE.Processors.Models;

namespace CE.Processors.Interfaces
{
    public interface ICaixaEletronico
    {
        void MostrarMenu();
        void MostrarRelatorio(Carteira carteira);
        void DigitarQuantidadeCeulas();

        int PegaInput();
        void RealizarDeposito(ref Carteira carteira);
        void RealizarSaque(ref Carteira carteira);
    }
}