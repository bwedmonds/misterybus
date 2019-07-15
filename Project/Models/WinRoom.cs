using System;

namespace Misterybus.Project.Models
{
  public class WinRoom : Room
  {
    private static string name;

    string AltDescription { get; set; }

    public void Look(bool alt)
    {
      if (alt)
      {
        Console.WriteLine(AltDescription);
      }
      else
      {
        Console.WriteLine();
      }
    }

    public WinRoom(string description, string altDescription) : base(name, description)
    {
      AltDescription = altDescription;

    }
  }
}
