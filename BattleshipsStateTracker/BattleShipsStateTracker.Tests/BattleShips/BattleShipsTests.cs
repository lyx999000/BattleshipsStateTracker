using Xunit;
using BattleshipsStateTracker.GameObjects.BattleShips;
using BattleshipsStateTracker.GameObjects.Enums;

namespace BattleShipsStateTracker.Tests.BattleShips
{
  public class BattleShipsTests
  {
    [Fact]
    public void ShouldCreateBattleship()
    {
      var ship = new Battleship();
      Assert.NotNull(ship);
      Assert.Equal(ShipName.Battleship, ship.Name);
      Assert.Equal(CellType.Battleship, ship.CellType);
      Assert.Equal(4, ship.Size);
    }

    [Fact]
    public void ShouldCreateCarrier()
    {
      var ship = new Carrier();
      Assert.NotNull(ship);
      Assert.Equal(ShipName.Carrier, ship.Name);
      Assert.Equal(CellType.Carrier, ship.CellType);
      Assert.Equal(5, ship.Size);
    }

    [Fact]
    public void ShouldCreateDestroyer()
    {
      var ship = new Destroyer();
      Assert.NotNull(ship);
      Assert.Equal(ShipName.Destroyer, ship.Name);
      Assert.Equal(CellType.Destroyer, ship.CellType);
      Assert.Equal(3, ship.Size);
    }

    [Fact]
    public void ShouldCreateSubmarine()
    {
      var ship = new Submarine();
      Assert.NotNull(ship);
      Assert.Equal(ShipName.Submarine, ship.Name);
      Assert.Equal(CellType.Submarine, ship.CellType);
      Assert.Equal(3, ship.Size);
    }

    [Fact]
    public void ShouldCreatePatrolBoat()
    {
      var ship = new PatrolBoat();
      Assert.NotNull(ship);
      Assert.Equal(ShipName.PatrolBoat, ship.Name);
      Assert.Equal(CellType.PatrolBoat, ship.CellType);
      Assert.Equal(2, ship.Size);
    }
  }
}