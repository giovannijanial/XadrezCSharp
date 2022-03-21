using Tabuleiro;
using ProjetoXadrez.Enums;

namespace ProjetoXadrez.Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroXadrez tab, Cor cor) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
