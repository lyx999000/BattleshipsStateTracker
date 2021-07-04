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

    public bool AddShip(Ships ship, Coordinates coordinates, ShipOrientation shipOrientation)
    {
      var startRow = coordinates.Row;
      var startCol = coordinates.Col;
      var endRow = startRow;
      var endCol = startCol;
      switch (shipOrientation)
      {
        case ShipOrientation.Vertical:
          endRow += ship.Size - 1;
          break;
        case ShipOrientation.Horizontal:
          endCol += ship.Size - 1;
          break;
      }

      var selectedCells = Board.BoardCells.Where(x => x.Coordinates.Row >= startRow 
                                                      && x.Coordinates.Col >= startCol 
                                                      && x.Coordinates.Row <= endRow 
                                                      && x.Coordinates.Col <= endCol).ToList();
      // Check target cell is occupied or is out of 10x10 board boundary
      if (selectedCells.Any(x => x.IsOccupied) || selectedCells.Count < ship.Size)
      {
        return false;
      }

      foreach (var cell in selectedCells)
      {
        cell.CellType = ship.CellType;
      }

      return true;
    }
    public Coordinates Shot(int x, int y)
    {
      return new Coordinates(x, y);
    }

    public ShotResult GetShotResult(Coordinates coordinates)
    {
      var cell = Board.BoardCells.First(x => x.Coordinates.Row == coordinates.Row && x.Coordinates.Col == coordinates.Col);
      if (!cell.IsOccupied)
      {
        return ShotResult.Miss;
      }
      var ship = Ships.First(x => x.CellType == cell.CellType);
      ship.Hits += 1;
      if (ship.IsSunk)
      {
        Console.WriteLine("You sunk my " + ship.Name + " !");
      }
      return ShotResult.Hit;
    }
  }
}