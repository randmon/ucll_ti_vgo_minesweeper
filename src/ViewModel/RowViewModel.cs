using Cells;
using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class RowViewModel
    {
        public RowViewModel(GameViewModel game, int rowIndex)
        {
            Squares = Row(game, rowIndex);
        }

        public IEnumerable<SquareViewModel> Squares { get; }
        private IEnumerable<SquareViewModel> Row(GameViewModel game, int row)
        {
            List<SquareViewModel> result = new List<SquareViewModel>();
            for (int i = 0; i < game.Game.Value.Board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(new SquareViewModel(game, position));
            }
            return result;
        }
    }
}
