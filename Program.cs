namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dimension boardDimension = new Dimension();
            
            Board newBoard = new Board(boardDimension.UserDimension);
            Console.WriteLine("\n");
            SubsidiaryBoard subBoard = new SubsidiaryBoard(boardDimension.UserDimension);
            Console.WriteLine();
        }
    }
}
