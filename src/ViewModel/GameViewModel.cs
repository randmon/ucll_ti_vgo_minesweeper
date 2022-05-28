using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {

        public GameViewModel(IGame game)
        {
            Game = Cell.Create(game);
            //ICell<IGameBoard> board = gameCell.Derive(g => g.Board);
            Board = new GameBoardViewModel(Game);
            Status = Game.Derive(g => g.Status);
        }

        public GameBoardViewModel Board { get; }
        public ICell<IGame> Game { get; set; }
        public ICell<GameStatus> Status { get; set; }
    }
}
