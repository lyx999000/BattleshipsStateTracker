using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class Destroyer : Ships
  {
    public Destroyer()
    {
      Name = ShipName.Destroyer;
      Size = 3;
      CellType = CellType.Destroyer;
    }
  }
}