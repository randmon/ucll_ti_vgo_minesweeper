using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(IGame game)
        {
            ICell<IGame> gameCell = Cell.Create(game);
            ICell<IGameBoard> board = gameCell.Derive(g => g.Board);
            Board = new GameBoardViewModel(gameCell);
        }

        public GameBoardViewModel Board { get; }
    }
}
