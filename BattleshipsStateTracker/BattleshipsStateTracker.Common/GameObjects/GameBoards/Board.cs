using System.Collections.Generic;

namespace BattleshipsStateTracker.GameObjects.GameBoards
{
  public class Board
  {
    public Board()
    {
      // initialize game board
      BoardCells = new List<BoardCell>();
      for (var i = 1; i <= 10; i++)
      {
        for (var j = 1; j <= 10; j++)
        {
          BoardCells.Add(new BoardCell(i, j));
        }
      }
    }
    public List<BoardCell> BoardCells { get; set; }
  }
}