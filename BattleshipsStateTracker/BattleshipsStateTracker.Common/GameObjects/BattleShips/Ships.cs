using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class Ships
  {
    public ShipName Name { get; set; }
    public int Size { get; set; }
    public int Hits { get; set; }
    public CellType CellType { get; set; }
    public bool IsSunk => Hits >= Size;
  }
}