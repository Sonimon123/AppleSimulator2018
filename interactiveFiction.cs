using System;
using System.Collections.Generic;

public class InteractiveFiction
{

    public static List<Item> Inventory;

    static void Main(string[] args)
    {
        PlayGame();
    }
    public static void PlayGame()
    {
        List<Item> Inventory = new List<Item>();

        bool appflag = false;
        bool cont = false;
        bool eat = false;
        Item current = new Item("Blank");

        //Create out Game World

        Location bedroom = new Location("bedroom");
        bedroom.Description = "You are in your bedroom, the place where you can go to sleep whenever you're ready to recharge. You can fall asleep using the magical power of 'sleep'";
        Item bed = new Item("bed");
        bedroom.ItemList.Add(bed);
        bed.Description = "It's a super comfy bed.";

        Location kitchen = new Location("kitchen");
        kitchen.Description = "You are in the kitchen, where you can sustain yourself with food.";
        Item apple = new Item("apple");
        kitchen.ItemList.Add(apple);
        apple.Description = "It's a tasty looking apple";

        Location living = new Location("living room");
        living.Description = "You are in the living room, where you would be able to relax and watch some TV, if it was actually working";
        Item TV = new Item("TV");
        living.ItemList.Add(TV);
        TV.Description = "It's a pretty nice TV. Shame it's busted though";

        Location doorway = new Location("doorway");
        doorway.Description = "You are in the doorway, where you let in guests.";
        Item door = new Item("door");
        doorway.ItemList.Add(door);
        door.Description = "It's a pretty basic door. It's not that impressive";

        //Link Locations
        bedroom.East = kitchen;
        bedroom.South = living;
        kitchen.South = doorway;
        kitchen.West = bedroom;
        living.North = bedroom;
        living.East = doorway;
        doorway.West = living;
        doorway.North = kitchen;

        Location currentLocation;
        currentLocation = bedroom;

        Console.WriteLine("Welcome to Apple Simulator 2018!\n");

        //Game loop
        bool playing = true;
        while (playing)
        {
            // Print the description of the current location
            Console.WriteLine(currentLocation.GetLocation());



            // Get a command
            Console.Write(">");
            string command = Console.ReadLine();

            // Process the command
            string[] splitCommands = command.Split(' ');
            Console.WriteLine("\n");
            if (splitCommands[0] == "go")
            {
                if (splitCommands[1] == "north" && currentLocation.North != null)
                {
                    currentLocation = currentLocation.North;
                }
                else if (splitCommands[1] == "south" && currentLocation.South != null)
                {
                    currentLocation = currentLocation.South;
                }
                else if (splitCommands[1] == "east" && currentLocation.East != null)
                {
                    currentLocation = currentLocation.East;
                }
                else if (splitCommands[1] == "west" && currentLocation.West != null)
                {
                    currentLocation = currentLocation.West;
                }
                else
                {
                    Console.WriteLine("You tried to go " + splitCommands[1] + ", but there was nothing there");
                }

            }

            else if (splitCommands[0] == "examine")
            {
                foreach (Item item in currentLocation.ItemList)
                {
                    if (item.Name == splitCommands[1])
                    {
                        cont = true;
                        current = item;

                    }
                }

                foreach (Item item in Inventory)
                {
                    if (item.Name == splitCommands[1])
                    {
                        cont = true;
                        current = item;

                    }
                }

                if (cont == true)
                {
                    Console.WriteLine(current.Description + "\n");
                }
                else
                {
                    Console.WriteLine("You turned to look at the " + splitCommands[1] + ", but it dissapeared. Was it ever there? (Probably not");
                }
            }

            else if (splitCommands[0] == "get" || splitCommands[0] == "take")
            {
                //Console.WriteLine(splitCommands[1]);
                foreach (Item item in currentLocation.ItemList)
                {
                    if (item.Name == splitCommands[1])
                    {
                        cont = true;
                        current = item;
                    }
                }
                if (cont == true)
                {
                    if (splitCommands[1] != "apple")
                    {
                        Console.WriteLine("I don't think that's how that works");
                        cont = false;
                    }
                    else
                    {
                        Inventory.Add(current);
                        currentLocation.ItemList.Remove(current);
                        appflag = true;
                        cont = false;

                    }
                }
                else
                {
                    Console.WriteLine("You reached out for a(n) " + splitCommands[1] + ", but it never came...");
                }
            }

            else if (splitCommands[0] == "drop")
            {
                foreach (Item item in currentLocation.ItemList)
                {
                    if (item.Name == splitCommands[1])
                    {
                        cont = true;
                        current = item;

                    }
                }
                if (cont == true)
                {
                    currentLocation.ItemList.Add(current);
                    Inventory.Remove(current);
                    cont = false;
                }
                else
                {
                    Console.WriteLine("You tried to drop a " + splitCommands[1] + ". Sadly, that's pretty hard, since you don't have one.");
                }
            }

            else if (splitCommands[0] == "eat")
            {
                foreach (Item item in currentLocation.ItemList)
                {
                    if (item.Name == splitCommands[1])
                    {
                        cont = true;
                        current = item;

                    }
                }
                if (current == apple)
                {
                    Inventory.Remove(current);
                    eat = true;
                    Console.WriteLine("Man, that was tasty!");
                }
            }

            else if (splitCommands[0] == "open")
            {
                if (splitCommands[1] == "door" && currentLocation == doorway)
                {
                    Console.WriteLine("You see a man in the doorway. 'Hello!' he says. 'Do you have any apples?' Type Y or N");
                    string answer = Console.ReadLine();
                    if (answer == "Y")
                    {
                        Console.WriteLine("'Great!' The man says. 'Could I have it please?' Type Y or N");
                        answer = Console.ReadLine();
                        if (answer == "Y")
                            if (!Inventory.Contains(apple))
                            {
                                Console.WriteLine("You tried to give him the apple, and failed because you don't have it. You close the door to go to sleep.");
                                Console.WriteLine("Attained 'Failed Boy' Ending");
                                playing = false;
                            }
                            else
                            {
                                Console.WriteLine("'Oh my god, thank you so much! said the man, ecstatic.\nThe man bites into the apple, his expression that of pure joy. He leaves with a newfound spring in his step, and you feel good having done a good deed.\n");
                                Console.WriteLine("Attained 'Good Boy' Ending");
                                playing = false;
                            }
                    }
                    if (answer == "N")
                    {
                        Console.WriteLine("'No!' you yell with a hatefull sneer. You slam the door in his face, and as you do, the wall above the door begins to crack. The crack grows larger, as it spreads throught the walls.\nEventually, the house loses it's integrity, and it breaks down crushing you. Maybe you'll be nicer in a future life.");
                        Console.WriteLine("Attained 'Dead Boy' Ending");
                        playing = false;
                    }

                    if (answer == "N")
                    {
                        Console.WriteLine("'Oh, OK then.' The man says, with a sad look on his face. The man leaves.");
                        appflag = false;
                    }
                }
            }

            else if (splitCommands[0] == "sleep")
            {
                if (currentLocation == bedroom)
                {
                    Console.WriteLine("You fall down on your bed and go to sleep. You had a fairly good day, but somehow, you feel that things could have gone better. Maybe tomorrow will be a better day.\n");
                    Console.WriteLine("Attained 'Sleepy Boy' Ending");
                    playing = false;
                }
            }



            else if (command == "inventory")
            {
                Console.WriteLine("*** Inventory ***");
                foreach (Item item in Inventory)
                {
                    Console.WriteLine("\t" + item.Name);
                }
            }

            else if (command == "exit")
            {
                playing = false;
            }

            else
            {
                Console.WriteLine("You tried to " + splitCommands[0] + ", and failed");
            }

            if (appflag == true && Inventory.Contains(apple) == true && playing == true)
            {
                Console.WriteLine("You hear a knock at the door. You're feeling kind of hungry.");
            }

            if (appflag == true && eat == true && playing == true)
            {
                Console.WriteLine("You hear a knock at the door. You're feeling tired after you're 'meal'.");
            }

            // Start the loop over
        }
    }
}