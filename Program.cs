using System;
using Misterybus.Project;
using Misterybus.Project.Interfaces;
using Misterybus.Project.Models;

namespace Misterybus
{
  public class Program
  {
    public static void Main(string[] args)
    {
      GameService gameService = new GameService();
      gameService.StartGame();
    }
  }
}
