using System;
using System.Collections.Generic;

public class Parser
{
    public Parser(string command)
    {
        string[] splitCommands = command.Split(' ');
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
                Console.WriteLine("You tried to go" + splitCommands[1] + ", but there was nothing there");
            }

        }

        if (splitCommands[0] == "get" || "take")
        {
            if (currentLocation.ItemList.contains(splitCommands[1]) = true)
            {
                if (splitCommands[1] = "apple")
                {
                    Inventory.Add(splitCommands[1]);
                    currentLocation.ItemList.Remove(splitCommands[1]);
                    appflag = true;
                }
                else
                {
                    Console.WriteLine("I don't think that's how that works");
                }
            }
            else
            {
                Console.WriteLine("You reached out for a" + splitCommands[1] + ", but it never came...");
            }
        }

        if (splitCommands[0] == "drop")
        {
            if (Inventory.contains(splitCommands[1]) = true)
            {
                currentLocation.ItemList.Add(splitCommands[1]);
                Inventory.Remove(splitCommands[1]);
            }
            else
            {
                Console.WriteLine("You tried to drop a " + splitCommands[1] + ". Sadly, that's pretty hard, since you don't have one.");
            }
        }

        if (command == "inventory")
        {
            Console.WriteLine("*** Inventory ***");
            foreach (Item item in Inventory)
            {
                Console.WriteLine("\t" + item.Name);
            }
        }

        if (command == "exit")
        {
            playing = false;
        }
    }
}