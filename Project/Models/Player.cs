using System.Collections.Generic;
using Misterybus.Project.Interfaces;

namespace Misterybus.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }


    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}