using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Program
    {
       static Game myGame;
    
        static void Main(string[] args)
        {
            Begin();
        }

            public static void Begin()
            {                
                    myGame = new Game();
                    myGame.CreateLevel();
                    myGame.Run();        
             
                
            }


    }    
}
