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

    // public void AddItem(Item item)
    // {
    //   Items.Add(item.Name.ToLower(), item)
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

    public IRoom TakeItem(string itemName)
    {
      if (Items.Contains(itemName))
      {
        return Items[itemName];
      }
      Console.WriteLine("That item must be a pixlated mirage...")
      return this;
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Exits = new Dictionary<string, IRoom>();
    }
  }
}