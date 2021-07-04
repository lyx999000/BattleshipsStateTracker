namespace BattleshipsStateTracker.GameObjects.GameBoards
{
  /// <summary>
  /// Base class for GameBoard Coordinates class
  /// </summary>
  public class Coordinates
  {
    public Coordinates(int row, int col)
    {
      Row = row;
      Col = col;
    }
    
    public int Row { get; set; }
    public int Col { get; set; }
  }
}