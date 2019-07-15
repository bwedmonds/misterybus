using System;
using System.Collections.Generic;
using System.Threading;
using Misterybus.Project.Interfaces;
using Misterybus.Project.Models;

namespace Misterybus.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    private bool Playing = true;

    #region game setup, start, reset and input
    public void Setup()
    {
      #region setup rooms
      Room bus = new Room("Mistery Bus", "An impossibly long bus... To the north, the windscreen is covered with a sunshade. To the south, east and west, there are exits.");
      Room hall = new Room("Hall of Memories", "A small room completely filled with blinking lights and glowing buttons...");
      Room hq = new Room("HQ", "A large room with what appears to be some sort of master control unit on a desk...");
      Room video = new Room("Surveillance", "Screens fill the entire front wall--one seems to show some unknown world...");
      //TODO this room gets it's own type that inherits from room. call it "fakewinroom" or whatever
      Room doors = new Room("Hall of Doors", "A small room with numerous doors. There is a desk in the middle with several buttons.");
      // TODO this room gets it's own type that inherits from room. call it "winroom" or whatever
      //Room slide = new Room("The Slide", "You're in a room with a slide that goes...");
      // TODO don't need this room because, when you push button the endgame script runs. move it to that function.
      #endregion

      #region setup items
      Item camera = new Item("Video Camera", "A barely functioning video camera.");
      Item cord = new Item("Phone Cord", "There's a phone code on the floor that doesn't seem to be hooked up to anything.");
      Item phone = new Item("Phone", "There's a phone wiht no dial tone on a desk...");
      Item thingy = new Item("Thingy", "There's a strange-looking square thingy with several electronic components on a slot in the wall.");
      Item button = new Item("Giant Red Button", "There's a Giant Red Button on a desk. It seems like it lights up, but isn't.");
      Item key = new Item("Key", "You find a key under a seat...");
      Item shade = new Item("Sunshade", "There's a sunshade covering the bus' front windshield...");
      #endregion

      #region setup & establish exits
      //bus.Exits.Add("north", video);
      //this is created when person removes shade
      bus.Exits.Add("east", doors);
      bus.Exits.Add("south", hq);
      bus.Exits.Add("west", hall);
      hall.Exits.Add("east", bus);
      video.Exits.Add("south", bus);
      hq.Exits.Add("north", bus);
      doors.Exits.Add("west", bus);
      //doors.Exits.Add("north", slide);
      #endregion

      #region establish items
      bus.Items.Add(key);
      bus.Items.Add(shade);
      video.Items.Add(camera);
      hq.Items.Add(cord);
      hq.Items.Add(phone);
      hall.Items.Add(thingy);
      doors.Items.Add(button);
      //TODO this button gets two descriptions so it can be on and off
      #endregion

      CurrentRoom = bus;
    }

    public void StartGame()
    {
      Console.Clear();
      Console.WriteLine("WELCOME TO THE MISTERY BUS.");
      string title = @"
         _______________________
         |,----.,----.,----.,--.\
         ||    ||    ||    ||   \\
         |`----'`----'|----||----\`.
         [            |   -||- __|(|
         [  ,--.      |____||.--.  |
         =-(( `))-----------(( `))==
            `--'             `--'
      ";
      Console.WriteLine(title);
      Thread.Sleep(1200);
      Console.WriteLine("THOUGH, YOU AREN'T HERE BY CHOICE...");
      Console.WriteLine();
      Thread.Sleep(1000);
      System.Console.WriteLine("Now that we have your attention: What is your name?");
      string playerName = Console.ReadLine();
      CurrentPlayer = new Player(playerName);
      Console.WriteLine();
      Console.WriteLine($"Abandon hope, {playerName}. Resistance, as they say, is futile.");
      Console.WriteLine();
      Console.WriteLine(CurrentRoom.Description);
      Console.WriteLine();
      Console.WriteLine("Enter 'help' if you're stuck.");

      while (Playing)
      {
        IRoom currentRoom = CurrentRoom;
        // Console.WriteLine($@"Current location:
        // {currentRoom.Name.ToUpper()}.");
        // Console.WriteLine();
        GetUserInput();
      }
    }
    public void Reset()
    {
      Console.Clear();
      // Setup();
      // Playing = true;
      StartGame();
    }
    public void GetUserInput()
    //TODO finish this
    {
      string input = Console.ReadLine().ToLower();
      string[] inputs = input.Split(' ');
      string command = inputs[0];
      string option = "";
      if (inputs.Length > 1)
      {
        option = inputs[1];
      }
      switch (command)
      {
        case "look":
          // Console.Clear();
          // if (CurrentRoom is WinRoom)
          // {
          //   WinRoom e = (WinRoom)CurrentRoom;
          //   e.Look(Connected);
          // }
          // else
          // {
          //   Look();
          // }
          Look();
          break;
        case "use":
          // case "slap":
          //   if (CurrentRoom is WinRoom && Connected)
          //   {
          //     EndGame();
          //     return;
          //   }
          UseItem(option);
          break;
        case "inventory":
          Inventory();
          break;
        case "quit":
          Quit();
          break;
        case "go":
          Go(option);
          break;
        case "reset":
          Reset();
          break;
        case "help":
          Help();
          break;
        case "take":
          // if (itemName == "shade" && CurrentRoom.Name == "bus")
          // {
          //   CurrentRoom.Exits.Add("north", video);
          // }
          TakeItem(option);
          break;
      }
    }
    #endregion

    #region console commands
    public void Go(string direction)
    {
      Console.Clear();
      Room dest = (Room)CurrentRoom.Go(direction);
      CurrentRoom = dest;
      CurrentRoom.Print();
    }

    public void Help()
    {
      Console.WriteLine(@"No shame in asking for help... 
       go: Oh the places you can go.
       take: If you want it, take it. 
       use: You got it, why not use it. 
       look: Observe your surroundings...
       inventory: Check your stuff.
       quit: Can't hack it? Then leave.
       reset: Will starting over give you an edge?");
      GetUserInput();
    }

    public void Inventory()
    {
      if (CurrentPlayer.Inventory.Count == 0)
      {
        Console.WriteLine("Delirium must be setting in --there's nothing here.");
      }
      foreach (var item in CurrentPlayer.Inventory)
      {
        Console.WriteLine($"Here's what you have: {item.Name}");
      }
    }

    public void Look()
    {
      Console.Clear();
      Console.WriteLine(CurrentRoom.Description);
    }

    public void Quit()
    {
      Playing = false;
      // Console.WriteLine("The Matrix has won! Good-bye.");
      Console.WriteLine();
      Console.WriteLine("Play again? y/n");
      ConsoleKeyInfo res = Console.ReadKey();
      if (res.KeyChar == 'y')
      {
        Setup();
        Playing = true;
        StartGame();
      }
      else if (res.KeyChar == 'n')
      {
        Console.WriteLine();
        Console.WriteLine("WE WILL FIND YOU AGAIN!");
        // Console.ReadLine();
        Environment.Exit(0);
      }
      else
      {
        Console.WriteLine();
        Quit();
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        Console.WriteLine($"Adding {item.Name}: {item.Description} to your inventory.");
      }
      else
      {
        Console.WriteLine("Are you losing touch with reality? That item must be a pixlated mirage...");
      }
    }

    public void UseItem(string itemName /*do i need bool available */)
    //TODO do this section
    {
      // List<Item> Inventory = AvailableItems;
      //throw new System.NotImplementedException();
    }

    #endregion

    public GameService()
    {
      Setup();
    }
  }
}