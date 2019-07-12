using System;
using System.Collections.Generic;
using Misterybus.Project.Interfaces;
using Misterybus.Project.Models;

namespace Misterybus.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    private bool Running = true;

    #region game setup, start, reset and input
    public void Setup()
    {
      #region setup rooms
      Room bus = new Room("Mistery Bus", "An impossibly long bus...");
      Room hall = new Room("Hall of Memories", "A small room completely filled with blinking lights and glowing buttons...");
      Room hq = new Room("HQ", "A large room with what appears to be some sort of master control unit on a desk...");
      Room video = new Room("Surveillance", "Screens fill the entire front wall--one seems to show some unknown world...");
      //TODO this room gets it's own type that inherits from room. call it "fakewinroom" or whatever
      Room doors = new Room("Hall of Doors", "A small room with numerous doors...");
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

    }
    public void Reset()
    {

    }
    public void GetUserInput()
    {

    }
    #endregion

    #region console commands
    public void Go(string direction)
    {
      CurrentRoom = (Room)CurrentRoom.Go(direction);
    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }



    public void TakeItem(string itemName)
    {
      CurrentRoom = (Room)CurrentRoom.TakeItem(itemName);
    }

    public void UseItem(string itemName)
    {
      //throw new System.NotImplementedException();
    }

    #endregion

    public GameService()
    {
      Setup();
      Running = true;
    }
  }
}