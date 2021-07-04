using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.GameBoards
{
  /// <summary>
  /// Base class for single cell in the GameBoard
  /// </summary>
  public class BoardCell
  {
    public BoardCell(int row, int col)
    {
      Coordinates = new Coordinates(row, col);
      CellType = CellType.Empty;
    }
    public Coordinates Coordinates { get; set; }
    public CellType CellType { get; set; }
    public string GetStatus => CellType.ToString();
    public bool IsOccupied => CellType == CellType.Battleship || 
                              CellType == CellType.Carrier ||
                              CellType == CellType.PatrolBoat ||
                              CellType == CellType.Destroyer ||
                              CellType == CellType.Submarine;
  }
}