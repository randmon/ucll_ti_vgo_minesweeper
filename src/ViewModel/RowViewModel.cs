using Cells;
using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class RowViewModel
    {
        public RowViewModel(ICell<IGame> game, int rowIndex)
        {
            Squares = Row(game, rowIndex);
        }

        public IEnumerable<SquareViewModel> Squares { get; }
        private IEnumerable<SquareViewModel> Row(ICell<IGame> game, int row)
        {
            List<SquareViewModel> result = new List<SquareViewModel>();
            for (int i = 0; i < game.Value.Board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(new SquareViewModel(game, position));
            }
            return result;
        }
    }
}
