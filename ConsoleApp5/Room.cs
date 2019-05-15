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
        
        public List<Monstre> enemis = new List<Monstre>();
            
        public void Decrit()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(description);
            foreach (var item in enemis)
            {
                Console.WriteLine(item.warCry);
            }
            Console.WriteLine("The room contains");
            if (objets.Count == 0)
            {
                Console.WriteLine("nothing");
            }
            else
            {
                foreach (var item in objets.Keys)
                {
                    Console.WriteLine(item);
                }
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
