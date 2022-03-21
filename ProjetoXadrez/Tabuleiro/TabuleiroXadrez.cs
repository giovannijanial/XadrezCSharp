
namespace Tabuleiro
{
    class TabuleiroXadrez
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public TabuleiroXadrez()
        {

        }

        public TabuleiroXadrez(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
    }
}
