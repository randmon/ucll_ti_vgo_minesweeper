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
        public IEnumerable<IEnumerable<Square>> Rows { get; }

        private IEnumerable<IEnumerable<Square>> GetRows()
        {
            List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();
            for (int i = 0; i < _board.Height; i++)
            {
                result.Add(Row(i));
            }
            return result;
        }


        private IEnumerable<Square> Row(int row)
        {
            List<Square> result = new List<Square>();
            for (int i = 0; i < _board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(_board[position]);
            }
            return result;
        }
    }
}
