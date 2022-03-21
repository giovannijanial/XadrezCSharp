using System.Collections.Generic;
using Tabuleiro;
using ProjetoXadrez.Enums;
using ProjetoXadrez.Xadrez;
using Tabuleiro.Exceptions;

namespace Xadrez
{
    class PartidaXadrez
    {
        public TabuleiroXadrez Tab { get; private set; }
        public int Turno { get; set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> Pecas { get; set; }
        public HashSet<Peca> Capturadas { get; set; }

        public PartidaXadrez()
        {
            Tab = new TabuleiroXadrez(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;          
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento (Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementaQtdeMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJodador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(Tab.Peca(pos) == null)
            {
                throw new TabuleiroExceptions("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroExceptions("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroExceptions("Não ha movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMover(destino))
            {
                throw new TabuleiroExceptions("Posição de destino invalida!");
            }
        }

        private void MudaJodador()
        {
            if (JogadorAtual == Cor.Branco)
                JogadorAtual = Cor.Preto;
            else
                JogadorAtual = Cor.Branco;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branco));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preto));

        }
    }
}
