using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SubsidiaryBoard
    {
        public string[,] GameBoard { get; private set; }
        public bool UserMove { get; private set; } = false;
        public bool GameOver { get; private set; } = false;

        public SubsidiaryBoard (int dimension)
        {
            GameBoard = new string[dimension, dimension];
            FillSubsidiaryBoard();
            //DisplayBoard();
        }

        private void FillSubsidiaryBoard() //metoda wstawia numerację pól np. A1
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                Rows letter = (Rows)i;
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    GameBoard[i, j] = $" {letter}{j + 1}";
                }
            }
        }

        public void DisplayBoard()
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
                    Console.Write(GameBoard[i, j]);
                    if (j < GameBoard.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < GameBoard.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    Console.Write("   ");
                    for (int j = 0; j < (GameBoard.GetLength(1) * 4) - 1; j++)
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
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (userMove.ToUpper() == GameBoard[i, j])
                    {
                        GameBoard[i, j] = " # ";
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
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] == " # ")
                    {
                        countMoves++;
                    }
                }
            }
            if (countMoves == GameBoard.GetLength(0) * GameBoard.GetLength(1))
            {
                GameOver = true;
            }
        }

    }
}
