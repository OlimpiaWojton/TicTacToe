namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Player p1, p2;
                CreatePlayers(out p1, out p2);
                Dimension boardDimension = new Dimension();

                Board gameBoard = new Board(boardDimension.UserDimension);
                Console.WriteLine("\n");
                SubsidiaryBoard subBoard = new SubsidiaryBoard(boardDimension.UserDimension);
                Console.WriteLine();

                while (!gameBoard.Won && !subBoard.GameOver)
                {
                    ReadAndValidateUserMove(subBoard, gameBoard, p1);

                    if (gameBoard.Won == true)
                    {
                        break;
                    }
                    (p1, p2) = (p2, p1);
                    subBoard.CheckGameOver();
                }
                if (gameBoard.Won == true)
                {
                    Console.WriteLine($" {p1.Name} Won!");
                }
                else if (subBoard.GameOver == true)
                {
                    Console.WriteLine("Board full, game over");
                }
            } while (PlayAgain());
        }

        private static void CreatePlayers(out Player p1, out Player p2)
        {
            p1 = new Player();
            AskAboutUsersNames(p1, " X ");
            p2 = new Player();
            AskAboutUsersNames(p2, " O ");
        }

        public static void AskAboutUsersNames(Player p, string sign)
        {
            p.Sign = sign;
            Console.WriteLine($"Write player \"{p.Sign}\" name");
            p.Name = Console.ReadLine();
        }

        public static void ReadAndValidateUserMove(SubsidiaryBoard subBoard, Board gameBoard, Player p)
        {
            string answer;

            do
            {
                Console.Clear();
                Console.WriteLine($"\n Player \"{p.Sign}\" move\n");
                gameBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("Take your move");
                answer = " " + Console.ReadLine();
                subBoard.CheckUserMove(answer, gameBoard, p);
                if (subBoard.UserMove == true)
                {
                    Console.WriteLine("Invalid input or field is occupied, try again");
                    Thread.Sleep(1500);
                }
                CheckIfUserWon(gameBoard, p);
                if (gameBoard.Won == true || subBoard.GameOver == true)
                {
                    Console.Clear();
                    gameBoard.DisplayBoard();
                    Console.WriteLine();
                }
            } while (subBoard.UserMove);
        }

        public static void CheckIfUserWon(Board gameBoard, Player p)
        {
            gameBoard.CheckHorizontal(p);
            gameBoard.CheckVertical(p);
            gameBoard.CheckDiagonalAsc(p);
            gameBoard.CheckDiagonalDesc(p);

        }

        public static bool PlayAgain()
        {
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("\nIf you want to play again press y if not press another button");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
