﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Game
    {
        Dictionary<string, int> inventaire = new Dictionary<string, int>();

        Dictionary<string, string> effects = new Dictionary<string, string>()
        {
            {"potion", "Refreshing!" },
            {"staff", "By fire be purged!" },
            {"deuillegivre","Vos cris d'agonie seront un hymne à ma puissance illimitée"},
            {"pikachu", "PIKAAAAAAACHUUUUUUUUUUUUUUUUUUUUUUUU" },
            {"bike", "Now is not the time to use that..." },

        };


        public List<Room> roomList = new List<Room>();

    
        public void Run()
        {

            roomList.Add(new Room("Bienvenue dans le donjon", 0));
            roomList[0].sorties.Add("north", 1);

                 
            roomList.Add(new Room("La chambre des secrets", 1));
            roomList[1].sorties.Add("east", 2);
            roomList[1].sorties.Add("west", 3);

                 
            roomList.Add(new Room("Nulle part", 2));
            roomList[2].sorties.Add("north", 4);
            roomList[2].sorties.Add("west", 1);
                 

                 Console.WriteLine(roomList[0].description);



                while (true)
                {

                    var input = Console.ReadLine();
                    var inputSplit = input.Split(' ');
                    var commande = inputSplit[0].ToLower();
                    var chose = inputSplit[1].ToLower();

                    var currentRoom = roomList[0];
               


                    switch (commande)
                    {
                        case ("take"):
                            Take(chose);
                            break;

                        case ("drop"):
                            Drop(chose);
                            break;

                        case ("use"):
                            Use(chose);
                            break;

                        case ("go"):
                            Go(chose);
                            break;

                        default:
                            Console.WriteLine("I didn't understand");
                            break;

                    }

                }

            void Go(string chose)
            {
                 
            }
            
            void Take(string chose)
            {
                Console.WriteLine("You took " + chose);
                if (!inventaire.ContainsKey(chose))
                {
                    inventaire.Add(chose, 1);
                }
                else
                {
                    inventaire[chose]++;
                }
                Console.WriteLine(string.Format("You have {0} {1} in your inventory", inventaire[chose], chose));
            }

            void Drop(string chose)
            {
                if (!inventaire.ContainsKey(chose))
                {
                    Console.WriteLine("No cheating!");
                }
                else if (inventaire[chose] <= 0)
                {
                    Console.WriteLine("You can't drop " + chose + " because you don't have any");
                }
                else
                {
                    Console.WriteLine("You dropped a " + chose);
                    minusOne(chose);
                }
            }

            void Use(string chose)

            {
                if (!inventaire.ContainsKey(chose))
                {
                    Console.WriteLine("No cheating!");
                }
                else if (inventaire[chose] <= 0)
                {
                    Console.WriteLine("You don't have any " + chose + " anymore");
                }
                else if (effects.ContainsKey(chose))
                {
                    Console.WriteLine(effects[chose]);
                    minusOne(chose);
                }
                else
                {
                    Console.WriteLine("You're probably too stupid to use that...");
                }


            }

            void minusOne(string chose)
            {
                inventaire[chose]--;
                Console.WriteLine(string.Format("You have {0} {1} in your inventory", inventaire[chose], chose));
            }
        }
    }
}
