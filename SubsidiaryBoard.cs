using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SubsidiaryBoard
    {
        public string[,] SubBoard { get; private set; }
        public bool UserMove { get; private set; } = false;
        public bool GameOver { get; private set; } = false;

        public SubsidiaryBoard (int dimension)
        {
            SubBoard = new string[dimension, dimension];
            FillSubsidiaryBoard();
            //DisplayBoard();
        }

        private void FillSubsidiaryBoard() //metoda wstawia numerację pól np. A1
        {
            for (int i = 0; i < SubBoard.GetLength(0); i++)
            {
                Rows letter = (Rows)i;
                for (int j = 0; j < SubBoard.GetLength(1); j++)
                {
                    SubBoard[i, j] = $" {letter}{j + 1}";
                }
            }
        }

        public void DisplayBoard()
        {
            Console.Write("   ");
            for (int x = 1; x <= SubBoard.GetLength(0); x++)
            {
                Console.Write($" {x}  ");
            }
            Console.WriteLine();
            for (int i = 0; i < SubBoard.GetLength(0); i++)
            {
                Rows letter = (Rows)i;
                Console.Write($" {letter} ");
                for (int j = 0; j < SubBoard.GetLength(1); j++)
                {
                    Console.Write(SubBoard[i, j]);
                    if (j < SubBoard.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < SubBoard.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    Console.Write("   ");
                    for (int j = 0; j < (SubBoard.GetLength(1) * 4) - 1; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
        public void CheckUserMove(string userMove, Board board, Player p)
        {
            bool contains = false;
            for (int i = 0; i < SubBoard.GetLength(0); i++)
            {
                for (int j = 0; j < SubBoard.GetLength(1); j++)
                {
                    if (userMove.ToUpper() == SubBoard[i, j])
                    {
                        SubBoard[i, j] = " # ";
                        board.GameBoard[i, j] = p.Sign;
                        contains = true;
                        break;
                    }
                }
                if (contains == true)
                {
                    break;
                }
            }
            if (contains == false)
            {
                //Console.WriteLine("Invalid input or field is occupied, try again");
                UserMove = true;
            }
            else
            {
                UserMove = false;
            }
        }

        public void CheckGameOver()
        {
            int countMoves = 0;
            for (int i = 0; i < SubBoard.GetLength(0); i++)
            {
                for (int j = 0; j < SubBoard.GetLength(1); j++)
                {
                    if (SubBoard[i, j] == " # ")
                    {
                        countMoves++;
                    }
                }
            }
            if (countMoves == SubBoard.GetLength(0) * SubBoard.GetLength(1))
            {
                GameOver = true;
            }
        }

    }
}
