using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleshipsStateTracker.GameObjects.BattleShips
{
  public class Submarine : Ships
  {
    public Submarine()
    {
      Name = ShipName.Submarine;
      Size = 3;
      CellType = CellType.Submarine;
    }
  }
}