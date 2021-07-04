using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class PatrolBoat : Ships
  {
    public PatrolBoat()
    {
      Name = ShipName.PatrolBoat;
      Size = 2;
      CellType = CellType.PatrolBoat;
    }
  }
}