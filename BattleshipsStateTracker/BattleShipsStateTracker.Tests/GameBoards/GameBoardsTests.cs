using BattleshipsStateTracker.GameObjects.Enums;
using BattleshipsStateTracker.GameObjects.GameBoards;
using Xunit;

namespace BattleShipsStateTracker.Tests.GameBoards
{
  public class GameBoardsTests
  {
    [Fact]
    public void ShouldCreateBoard()
    {
      var board = new Board();
      Assert.NotNull(board);
    }
    
    [Fact]
    public void ShouldCreateBoardWithCorrectSize()
    {
      var board = new Board();
      Assert.NotNull(board);
      Assert.Equal(10*10, board.BoardCells.Count);
    }
  }
}