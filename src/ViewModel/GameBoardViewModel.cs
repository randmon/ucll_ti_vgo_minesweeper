using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly IGameBoard _board;

        public GameBoardViewModel(IGame game)
        {
            _board = game.Board;
            Rows = GetRows(game);
        }
        public IEnumerable<RowViewModel> Rows { get; }

        private IEnumerable<RowViewModel> GetRows(IGame game)
        {
            List<RowViewModel> result = new List<RowViewModel>();
            for (int i = 0; i < _board.Height; i++)
            {
                result.Add(new RowViewModel(game, i));
            }
            return result;
        }
    }
}
