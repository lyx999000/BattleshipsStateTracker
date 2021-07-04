using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class Battleship : Ships
  {
    public Battleship()
    {
      Name = ShipName.Battleship;
      Size = 4;
      CellType = CellType.Battleship;
    }
  }
}