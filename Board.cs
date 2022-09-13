using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        public string[,] GameBoard { get; private set; }
       
        public Board (int dimension)
        {
            GameBoard = new string[dimension, dimension];
            FillBoard();
            DisplayBoard();
        }

        private void FillBoard()
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    GameBoard[i, j] = "   ";
                }
            }
        }

        private void DisplayBoard()
        {
            Console.Write("   ");
            for (int x = 1; x <= GameBoard.GetLength(0); x++)
            {
                Console.Write($" {x}  ");
            }
            Console.WriteLine();
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                Rows letter = (Rows)i;
                Console.Write($" {letter} ");
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    Console.Write(GameBoard[i,j]);
                    if (j < GameBoard.GetLength(1) -1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < GameBoard.GetLength(0) -1)
                {
                    Console.WriteLine();
                    Console.Write("   ");
                    for (int j = 0; j < (GameBoard.GetLength(1) * 4) -1; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
            }
        }
        private void FillSubsidiaryBoard() //metoda wstawia numerację pól np. A1
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                Rows letter = (Rows)i;
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    GameBoard[i, j] = $" {letter}{j +1}";
                }
            }
        }
    }
}
