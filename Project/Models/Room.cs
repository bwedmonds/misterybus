using System;
using System.Collections.Generic;
using Misterybus.Project.Interfaces;

namespace Misterybus.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    //TODO do i need to validate room such as...
    // public void ValidateRoom(string direction)
    // {
    //   Console.WriteLine("You're in");
    // }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      Console.WriteLine("Does not compute.");
      return this;
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }
    public void UseItem(string usableItem)
    {
      // System.Console.WriteLine($"You have used the {usableItem} in the {Name} room.");
      if (Name == "doors" && usableItem == "button")
      {
        Description = @"The door opens and a vortex appears, sucking you in and spitting you back out in your room. You coded too much and got pulled into the interwebs. But, you're back and ready to code again! You win!";
      }
      // else if (Name == "bus" && usableItem == "sunshade")
      // {
      //   Console.WriteLine("If you had another bus you could use it. It's no good to you here.");
      // }
      else
      {
        System.Console.WriteLine("Not sure why you'd want to do that. It ain't gonna work.");
      }
      System.Console.WriteLine(Description);
    }

    public void Print()
    {
      Console.WriteLine(Description);
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, IRoom>();
      Items = new List<Item>();
    }
  }
}