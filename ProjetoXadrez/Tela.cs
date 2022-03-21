using Tabuleiro;
using System;
using ProjetoXadrez.Enums;
using ProjetoXadrez.Xadrez;

namespace ProjetoXadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(TabuleiroXadrez tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("-  ");
                    }
                    else
                    {
                        ImprimirPeça(tab.Peca(i, j));
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1]+"");

            return new PosicaoXadrez(coluna, linha);
        }

        static void ImprimirPeça(Peca peca)
        {
            if (peca.Cor == Cor.Branco)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
