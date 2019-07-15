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