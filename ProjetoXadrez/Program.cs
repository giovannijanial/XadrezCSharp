using System;
using Tabuleiro;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao p = new Posicao(2, 3);
            TabuleiroXadrez tab = new TabuleiroXadrez(8,8);
            Tela.ImprimirTabuleiro(tab);

            Console.ReadKey();
        }
    }
}
