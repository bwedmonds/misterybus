using System.Collections.Generic;
using Misterybus.Project.Models;

namespace Misterybus.Project.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
