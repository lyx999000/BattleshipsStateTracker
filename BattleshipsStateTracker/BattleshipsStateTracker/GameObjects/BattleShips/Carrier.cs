using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class Carrier : Ships
  {
    public Carrier()
    {
      Name = ShipName.Carrier;
      Size = 5;
      CellType = CellType.Carrier;
    }
  }
}