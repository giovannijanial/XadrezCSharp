﻿using System;
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
                    try
                    {


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);


                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.RealizaJogada(origem, destino);
                    }catch(TabuleiroExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
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
