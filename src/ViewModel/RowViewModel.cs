using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class RowViewModel
    {
        public IEnumerable<SquareViewModel> Squares { get; }
        public RowViewModel(IGame game, int rowIndex)
        {
            Squares = Row(game, rowIndex);
        }

        private IEnumerable<SquareViewModel> Row(IGame game, int row)
        {
            List<SquareViewModel> result = new List<SquareViewModel>();
            for (int i = 0; i < game.Board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(new SquareViewModel(game, position));
            }
            return result;
        }
    }
}
