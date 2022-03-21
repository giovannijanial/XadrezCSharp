using System;
using Tabuleiro;
using Xadrez;
using ProjetoXadrez.Xadrez;
using ProjetoXadrez.Enums;
using Tabuleiro.Exceptions;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroXadrez tab = new TabuleiroXadrez(8,8);
            try
            {
                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMobimento(origem, destino);
                }
                
            }
            catch(TabuleiroExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadKey();
        }

    }
}
