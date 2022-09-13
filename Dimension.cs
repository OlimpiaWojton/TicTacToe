using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Dimension
    {
        public int UserDimension { get; private set; }

        public Dimension()
        {
            AskUserAboutDimension();
            ReadAndValidateDimension();
        }

        private void AskUserAboutDimension()
        {
            Console.WriteLine("Choose dimension of your board, min 3 x 3, max 10 x 10");
            Console.WriteLine("Put the number ex. 5 for 5 x 5");
        }
        private void ReadAndValidateDimension()
        {
            int userAswer;
            while (!int.TryParse(Console.ReadLine(), out userAswer) || (userAswer < 3 || userAswer > 10))
            {
                Console.WriteLine("Invalid input, choose between 3 to 10");
            }
                UserDimension = userAswer;
        }
        private void CheckDimension() //nieużywana
        {
            UserDimension = int.Parse(Console.ReadLine());
            while (true)
            {
                if (UserDimension == 3 || UserDimension == 5 || UserDimension == 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again, choose between 3, 5 and 7");
                    UserDimension = int.Parse(Console.ReadLine());
                }
            }
            
        }
      

       
    }
}
