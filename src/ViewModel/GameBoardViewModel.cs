using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly IGameBoard _board;

        public GameBoardViewModel(IGameBoard board)
        {
            _board = board;
            Rows = GetRows();
        }
        public IEnumerable<RowViewModel> Rows { get; }

        private IEnumerable<RowViewModel> GetRows()
        {
            List<RowViewModel> result = new List<RowViewModel>();
            for (int i = 0; i < _board.Height; i++)
            {
                result.Add(new RowViewModel(Row(i)));
            }
            return result;
        }


        private IEnumerable<SquareViewModel> Row(int row)
        {
            List<SquareViewModel> result = new List<SquareViewModel>();
            for (int i = 0; i < _board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(new SquareViewModel(_board[position]));
            }
            return result;
        }
    }
}
