using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Game
    {
              
        Room currentRoom;

        bool achievement1 = false;
        bool achievement2 = false;
        bool achievement3 = false;


        List<string> gotAchievements = new List<string>();
        Dictionary<int, string> achievements = new Dictionary<int, string>()
        {
            { 1, "Congrats, you looted a potion" },
            { 2, "Pika Pika" },
            { 3, "Your first kill! You now have bloods on your hand" }
        };
        Dictionary<string, int> inventaire = new Dictionary<string, int>();
        Dictionary<string, string> effects = new Dictionary<string, string>() 
        {
            {"potion", "Refreshing!" },
            {"staff", "By fire be purged!" },
            {"deuillelombre","Vos cris d'agonie seront un hymne à ma puissance illimitée"},
            {"pikachu", "PIKAAAAAAACHUUUUUUUUUUUUUUUUUUUUUUUU" },
            {"bike", "Now is not the time to use that..." },
        };

        public static List<Room> roomList = new List<Room>();

        public void CreateLevel()
        {
                    roomList.Clear();
                    //Room0
                    roomList.Add(new Room("Entrée du donjon", 0));

                    roomList[0].sorties.Add("north", 1);

                    roomList[0].objets.Add("potion", 1);

                    roomList[0].enemis.Add(new Monstre("Jean-Euclide me paraît menaçant", "Peut-être était-ce de l'overkill...", "staff"));

                    //Room1
                    roomList.Add(new Room("La chambre des secrets", 1));

                    roomList[1].sorties.Add("east", 2);
                    roomList[1].sorties.Add("west", 3);
                    roomList[1].sorties.Add("south", 0);

                    roomList[1].objets.Add("staff", 1);

                    //Room2
                    roomList.Add(new Room("Nulle part", 2));

                    roomList[2].sorties.Add("north", 4);
                    roomList[2].sorties.Add("west", 1);
                    
                    //Room3
                    roomList.Add(new Room("Stade Pokémon de Jotho", 3));

                    roomList[3].sorties.Add("east", 1);

                    roomList[3].objets.Add("pikachu", 1);

                    //Room4
                    roomList.Add(new Room("Super U de Hesdigneul-Les-Boulays", 4));


                    roomList[4].sorties.Add("south", 2);
                    roomList[4].sorties.Add("north", 5);

                    roomList[4].objets.Add("bike", 1);

                    roomList[4].enemis.Add(new Monstre("Le roi liche au super U?", "Plus facile qu'en 3.3.5", "deuillelombre"));
                    
                    //Room5
                    roomList.Add(new Room("La fin du monde", 5));

                    roomList[5].sorties.Add("south", 4);

                    roomList[5].objets.Add("deuillelombre", 1);

                    roomList[5].enemis.Add((new Monstre("Le dieu de la mort te fait coucou", "Littéralement épique", "pikachu", true)));

                    currentRoom = roomList[0];

        }

        public void Run()
        {           
            currentRoom.Decrit();
            Console.WriteLine("'Show commands' to get commands");
            bool isPlaying = true;

            while (isPlaying == true)
            {
                var input = Console.ReadLine();
                var inputSplit = input.Split(' ');  
                
                if (inputSplit.Length == 2)
                {                
                var commande = inputSplit[0].ToLower();
                var chose = inputSplit[1].ToLower();                  

                    // Input
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
                else
                {
                    Console.WriteLine("Commande foireuse");
                }
            }

            //Déplacement entre salles
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

            //Prendre objet
            void Take(string chose)
            {
                if (currentRoom.objets.ContainsKey(chose))
                {
                    if (currentRoom.objets[chose] > 0)
                    {
                        Console.WriteLine("You took " + chose);
                        if (!inventaire.ContainsKey(chose))
                        {
                            inventaire.Add(chose, 1);
                            if(chose == "potion" && !achievement1)
                            {
                                Console.WriteLine("You got an achievement!");
                                gotAchievements.Add(achievements[1]);
                                achievement1 = true;
                            }
                            else if(chose == "pikachu" && !achievement2)
                            {
                                Console.WriteLine("You got an achievement!");
                                gotAchievements.Add(achievements[2]);
                                achievement2 = true;
                            }
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

            //Jeter objet
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

            //Utiliser objet
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


                   for (int i = currentRoom.enemis.Count - 1; i >= 0; i--)
                    {
                        if (currentRoom.enemis[i].weakPoint == chose)
                        {
                            currentRoom.enemis[i].Die();
                            if(currentRoom.enemis[i].finalBoss == true)
                                {
                                EndGame();
                                } 
                            currentRoom.enemis.RemoveAt(i);
                            minusOne(chose);                                                                                       
                        }
                    }                   
                }
                else
                {
                    Console.WriteLine("You're probably too stupid to use that...");
                }

            }

            //Montrer des trucs
            void Show(string chose)
            {
                switch (chose)
                { 
                    case "room":                 
                        currentRoom.Decrit();                
                        break;

                    case ("inventory"):                
                    Console.WriteLine("Inventory : ");
                        if (inventaire.Count <= 0)
                        {
                            Console.WriteLine("Nothing");
                        }
                        else
                        {
                            foreach (var item in inventaire.Keys)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    break;

                    case ("commands"):
                        ShowCommands();
                        break;

                    case ("achievements"):
                        ShowAchievements();
                        break;

                    default:
                        Console.WriteLine("Show what ?");
                        break;
                }
            }
            //montrer les commandes
            void ShowCommands()
            {
                Console.WriteLine("'Take' to take an item");
                Console.WriteLine("'Drop' to drop an item");
                Console.WriteLine("'Use' to use an item");
                Console.WriteLine("'Go' to go somewhere");
                Console.WriteLine("'Show' inventory, room, commands");
            }

            //montrer les achievements

            void ShowAchievements()
            {
                foreach (var item in gotAchievements)
                {
                    Console.WriteLine(item);
                }
            }

            //Retirer objet de l'inventaire
            void minusOne(string chose)
            {
                inventaire[chose]--;
                Console.WriteLine(string.Format("You have {0} {1} in your inventory", inventaire[chose], chose));
            }

            //Fin du jeu
            void EndGame()
            {
                Console.WriteLine("Wow toutes mes félicitations!");
                Console.WriteLine("Rejouer?");
                var rejouer = Console.ReadLine();
                if (rejouer == "oui")
                {
                    Console.Clear();
                    CreateLevel();
                    currentRoom.Decrit();

                }
                else
                {
                    Console.WriteLine("Tu n'as pas d'autre choix, mortel!");
                    EndGame();
                }
            }                       
        }
    }
}
