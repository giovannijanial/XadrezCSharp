using ProjetoXadrez.Enums;

namespace Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public TabuleiroXadrez Tabuleiro { get; protected set; }

        public Peca()
        {

        }

        public Peca(Posicao posicao, Cor cor, TabuleiroXadrez tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdeMovimentos = 0;
        }
    }
}
