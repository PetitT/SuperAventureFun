using System;
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

        public void CreateLevel()
        {
         roomList.Add(new Room("Entrée du donjon", 0));

                    roomList[0].sorties.Add("north", 1);

                    roomList[0].objets.Add("potion", 1);

                 
                    roomList.Add(new Room("La chambre des secrets", 1));

                    roomList[1].sorties.Add("east", 2);
                    roomList[1].sorties.Add("west", 3);
                    roomList[1].sorties.Add("south", 0);

                    roomList[1].objets.Add("staff", 1);

                 
                    roomList.Add(new Room("Nulle part", 2));

                    roomList[2].sorties.Add("north", 4);
                    roomList[2].sorties.Add("west", 1);

                    roomList.Add(new Room("Stade Pokémon de Jotho", 3));

                    roomList[3].sorties.Add("east", 1);

                    roomList[3].objets.Add("pikachu", 1);

                    roomList.Add(new Room("Super U de Hesdigneul-Les-Boulays", 4));


                    roomList[4].sorties.Add("south", 2);
                    roomList[4].sorties.Add("north", 5);

                    roomList[4].objets.Add("bike", 1);

                    roomList.Add(new Room("Wow quelle aventure ce fut! Je n'en crois pas mes yeux, c'était tellement bien!", 5));

                    roomList[5].sorties.Add("south", 4);

                    roomList[5].objets.Add("deuillegivre", 1);

                    roomList[5].enemis.Add((new Monstre("Le dieu de la mort te fait coucou", "Littéralement épique")));
                    
            

                    
        }

        public void Run()
        {

           

                 var currentRoom = roomList[0];
                    Console.WriteLine("Bienvenue dans, genre le donjon le plus compliqué du monde");
                    currentRoom.Decrit();

                while (true)
                {

                    var input = Console.ReadLine();
                    var inputSplit = input.Split(' ');
                    var commande = inputSplit[0].ToLower();
                    var chose = inputSplit[1].ToLower();

                    
               


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

                        case ("show"):
                            Show(chose);
                            break;

                        default:
                            Console.WriteLine("I didn't understand");
                            break;

                    }

                }

            void Go(string chose)
            {
                 if (!currentRoom.sorties.ContainsKey(chose))
                {
                    Console.WriteLine("Lol tu t'es pris le mur");
                }
                 else
                {
                    currentRoom = roomList[currentRoom.sorties[chose]];
                    currentRoom.Decrit();
                    
                }
            }
            
            void Take(string chose)
            {
                if(currentRoom.objets.ContainsKey(chose))
                {
                    if(currentRoom.objets[chose]>0)
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
                           currentRoom.objets.Remove(chose);
                    }
                    else
                    {
                        Console.WriteLine("Il n'y en a plus...");
                    }

                }
                else
                {
                    Console.WriteLine("Il n'y a pas de " + chose + " ici"); 
                }

                
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
                    if (currentRoom.objets.ContainsKey(chose))
                    {
                        currentRoom.objets[chose]++;                        
                    }
                    else
                    {
                        currentRoom.objets.Add(chose, 1);
                    }
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

            void Show(string chose)
            {
                if (chose != "inventory")
                {
                    Console.WriteLine("Show what ?");
                }
                else
                {
                    Console.WriteLine("Inventory : ");
                    foreach (var item in inventaire.Keys)
                    {
                        Console.WriteLine(item);
                    }
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
