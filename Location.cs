using System;
using System.Collections.Generic;

public class Location
{
    public string Name;
    public string Description;
    public Location North;
    public Location South;
    public Location East;
    public Location West;


    // Constructor
    public Location(string name)
    {
        this.Name = name;
    }

    public List<Item> ItemList = new List<Item>();

    public string GetLocation()
    {
        string gameplayDescription = "\n";

        gameplayDescription += "***" + this.Name + "***\n";
        gameplayDescription += this.Description + "\n";

        if (this.North != null)
        {
            gameplayDescription += "To the north you see the " + this.North.Name + "\n";
        }
        if (this.East != null)
        {
            gameplayDescription += "To the east you see the " + this.East.Name + "\n";
        }
        if (this.West != null)
        {
            gameplayDescription += "To the west you see the " + this.West.Name + "\n";
        }
        if (this.South != null)
        {
            gameplayDescription += "To the south you see the " + this.South.Name + "\n";
        }

        gameplayDescription += "This room contains a(n)\n";

        foreach (Item item in this.ItemList)
        {
            gameplayDescription += ("\t" + item.Name + "\n");
        }
            return gameplayDescription;
    }
}