using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static Game myGame;

        static void Main(string[] args)
        {
            myGame = new Game();
            myGame.CreateLevel();
            myGame.Run();
        }
    }    
}
