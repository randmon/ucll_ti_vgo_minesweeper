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
                result.Add(new RowViewModel(Row(i, game), game, i));
            }
            return result;
        }


        private IEnumerable<SquareViewModel> Row(int row, IGame game)
        {
            List<SquareViewModel> result = new List<SquareViewModel>();
            for (int i = 0; i < _board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(new SquareViewModel(_board[position], game, position));
            }
            return result;
        }
    }
}
