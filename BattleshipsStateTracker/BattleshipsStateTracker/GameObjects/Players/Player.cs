using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipsStateTracker.GameObjects.BattleShips;
using BattleshipsStateTracker.GameObjects.Enums;
using BattleshipsStateTracker.GameObjects.GameBoards;

namespace BattleshipsStateTracker.GameObjects.Players
{
  public class Player
  {
    public Player(string name)
    {
      Name = name;
      Ships = new List<Ships>()
      {
        new Destroyer(),
        new Submarine(),
        new PatrolBoat(),
        new Battleship(),
        new Carrier()
      };
      Board = new Board();
    }
    public string Name { get; set; }
    public Board Board { get; set; }
    public List<Ships> Ships { get; set; }
    public bool IsLost => Ships.All(x => x.IsSunk);

    public Coordinates Shot(int x, int y)
    {
      return new Coordinates(x, y);
    }

    public ShotResult GetShotResult(Coordinates coordinates)
    {
      var cell = Board.BoardCells.First(x => x.Coordinates.Row == coordinates.Row && x.Coordinates.Col == coordinates.Col);
      if (!cell.IsOccupied)
      {
        Console.WriteLine("Miss!");
        return ShotResult.Miss;
      }
      var ship = Ships.First(x => x.CellType == cell.CellType);
      ship.Hits += 1;
      if (ship.IsSunk)
      {
        Console.WriteLine("You sunk my " + ship.Name + " !");
      }
      Console.WriteLine("Hit!");
      return ShotResult.Hit;
    }
  }
}