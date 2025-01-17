namespace TicTacToe
{
    class Board
    {
        public string[,] GameBoard { get; private set; }
        public bool Won { get; private set; } = false;

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
            Console.WriteLine();
        }

        public void CheckHorizontal(Player p)
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i,j] != p.Sign)
                    {
                        break;
                    }
                    if (j == GameBoard.GetLength(1) - 1)
                    {
                        Won = true;
                    }
                }

            }
        }

        public void CheckVertical(Player p)
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[j, i] != p.Sign)      //zamiana zmiennych i na j = pionowe przechodzenie po Array
                    {
                        break;
                    }
                    if (j == GameBoard.GetLength(1) - 1)
                    {
                        Won = true;
                    }
                }

            }
        }

        public void CheckDiagonalAsc(Player p)
        {
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                if (GameBoard[i, i] != p.Sign)
                {
                    break;
                }
                if (i == GameBoard.GetLength(1) - 1)
                {
                    Won = true;
                }
            }
        }

        public void CheckDiagonalDesc(Player p)
        {
            int j = GameBoard.GetLength(0) -1;
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                if (GameBoard[i, j] != p.Sign)
                {
                    break;
                }
                if (i == GameBoard.GetLength(1) - 1)
                {
                    Won = true;
                }
                j--;
            }
        }



        public void CheckHorizontal2(Player p)
        {
            for (int i = 0; i< GameBoard.GetLength(0);i++)
            {
                if (GameBoard[i, 0] == p.Sign && GameBoard[i,0] == GameBoard[i,1] && GameBoard[i,1] == GameBoard[i,2])
                {
                    Won = true;
                }
            }
        }

      
    }
}
