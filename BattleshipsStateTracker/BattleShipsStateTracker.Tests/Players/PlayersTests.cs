using System.Linq;
using BattleshipsStateTracker.GameObjects.BattleShips;
using BattleshipsStateTracker.GameObjects.Enums;
using BattleshipsStateTracker.GameObjects.GameBoards;
using BattleshipsStateTracker.GameObjects.Players;
using Xunit;

namespace BattleShipsStateTracker.Tests.Players
{
  public class PlayersTests
  {
    
    [Fact]
    public void ShouldCreatePlayer()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
    }
    
    [Fact]
    public void ShouldCreatePlayerWithShips()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
      Assert.NotNull(player.Ships.Where(x => x.Name == ShipName.Carrier));
      Assert.NotNull(player.Ships.Where(x => x.Name == ShipName.Carrier));
      Assert.NotNull(player.Ships.Where(x => x.Name == ShipName.Submarine));
      Assert.NotNull(player.Ships.Where(x => x.Name == ShipName.PatrolBoat));
    }
    
    [Fact]
    public void ShouldCreatePlayerWithBoard()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
      Assert.NotNull(player.Board);
    }
    
    [Fact]
    public void ShouldAddShipToPlayerBoard()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
      Assert.NotNull(player.Board);
      var result = player.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      Assert.True(result);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 1).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 2).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 3).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 4).CellType);
    }
    
    [Fact]
    public void ShouldNotAddShipToPlayerBoardWhenOccupied()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
      Assert.NotNull(player.Board);
      var result = player.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      Assert.True(result);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 1).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 2).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 3).CellType);
      Assert.Equal(CellType.Battleship, player.Board.BoardCells.First(x => x.Coordinates.Row == 1 && x.Coordinates.Col == 4).CellType);
      var secondResult = player.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      Assert.False(secondResult);
    }
    
    [Fact]
    public void ShouldReturnHitOrMissWhenGettingShot()
    {
      var player = new Player("Test");
      Assert.NotNull(player);
      Assert.Equal("Test", player.Name);
      Assert.NotNull(player.Board);
      player.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      Assert.Equal(ShotResult.Hit, player.GetShotResult(new Coordinates(1, 1)));
      Assert.Equal(ShotResult.Hit, player.GetShotResult(new Coordinates(1, 2)));
      Assert.Equal(ShotResult.Hit, player.GetShotResult(new Coordinates(1, 3)));
      Assert.Equal(ShotResult.Hit, player.GetShotResult(new Coordinates(1, 4)));
      Assert.Equal(ShotResult.Miss, player.GetShotResult(new Coordinates(1, 5)));
    }
    
    [Fact]
    public void ShouldGetBackAttackResultWhenAttackingTheOtherPlayer()
    {
      var player = new Player("Test");
      var player2 = new Player("Test2");
      player2.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      Assert.Equal(ShotResult.Hit, player2.GetShotResult(player.Shot(1, 1)));
      Assert.Equal(ShotResult.Hit, player2.GetShotResult(player.Shot(1, 2)));
      Assert.Equal(ShotResult.Hit, player2.GetShotResult(player.Shot(1, 3)));
      Assert.Equal(ShotResult.Hit, player2.GetShotResult(player.Shot(1, 4)));
      Assert.Equal(ShotResult.Miss, player2.GetShotResult(player.Shot(1, 5)));
    }

    [Fact]
    public void ShouldReturnWhetherPlayerHasLostGame()
    {
      var player = new Player("Test");
      var player2 = new Player("Test2");
      player.AddShip(new Battleship(), new Coordinates(1, 1), ShipOrientation.Horizontal);
      player.AddShip(new Carrier(), new Coordinates(2, 1), ShipOrientation.Horizontal);
      player.AddShip(new Submarine(), new Coordinates(3, 1), ShipOrientation.Horizontal);
      player.AddShip(new Destroyer(), new Coordinates(4, 1), ShipOrientation.Horizontal);
      player.AddShip(new PatrolBoat(), new Coordinates(5, 1), ShipOrientation.Vertical);
      Assert.False(player.IsLost);
      
      //Sunk BattleShip - 4 ships left
      player.GetShotResult(new Coordinates(1, 1));
      player.GetShotResult(new Coordinates(1, 2));
      player.GetShotResult(new Coordinates(1, 3));
      player.GetShotResult(new Coordinates(1, 4));
      Assert.False(player.IsLost);
      
      //Sunk Carrier - 3 ships left
      player.GetShotResult(new Coordinates(2, 1));
      player.GetShotResult(new Coordinates(2, 2));
      player.GetShotResult(new Coordinates(2, 3));
      player.GetShotResult(new Coordinates(2, 4));
      player.GetShotResult(new Coordinates(2, 5));
      Assert.False(player.IsLost);
      
      //Sunk Submarine - 2 ships left
      player.GetShotResult(new Coordinates(3, 1));
      player.GetShotResult(new Coordinates(3, 2));
      player.GetShotResult(new Coordinates(3, 3));
      Assert.False(player.IsLost);
      
      //Sunk Destroyer - 1 ship left
      player.GetShotResult(new Coordinates(4, 1));
      player.GetShotResult(new Coordinates(4, 2));
      player.GetShotResult(new Coordinates(4, 3));
      Assert.False(player.IsLost);
      
      //Sunk PatrolBoat - 0 ship left
      player.GetShotResult(new Coordinates(5, 1));
      player.GetShotResult(new Coordinates(6, 1));
      Assert.True(player.IsLost);
    }

  }
}