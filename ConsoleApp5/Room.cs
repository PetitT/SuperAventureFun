using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Room
    {
        public string description;
        public int id;
        
        public Dictionary<string, int> sorties = new Dictionary<string, int>();
        public Dictionary<string, int> objets = new Dictionary<string, int>();

        public void Decrit()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(description);
            Console.WriteLine("The room contains");
            foreach (var item in objets.Keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("There's an exit");
            foreach (var item in sorties.Keys)
            {
               Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");
        }

        public Room(string description, int id)
        {
            this.description = description;
            this.id = id;
        }
    }
}
