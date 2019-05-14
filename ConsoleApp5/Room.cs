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


        public Dictionary<string, int> sorties = new Dictionary<string, int>()
        {
        }
        
        ;


        public Room(string description, int id)
        {
            this.description = description;
            this.id = id;
        }
    }
}
