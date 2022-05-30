using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGameBoard> _board;

        public GameBoardViewModel(GameViewModel game)
        {
            _board = game.Game.Derive(g => g.Board);
            Rows = GetRows(game);
        }
        public IEnumerable<RowViewModel> Rows { get; }

        private IEnumerable<RowViewModel> GetRows(GameViewModel game)
        {
            List<RowViewModel> result = new List<RowViewModel>();
            for (int i = 0; i < _board.Value.Height; i++)
            {
                result.Add(new RowViewModel(game, i));
            }
            return result;
        }
    }
}
