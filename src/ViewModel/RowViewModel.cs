using Model.MineSweeper;

namespace ViewModel
{
    public class RowViewModel
    {
        public IEnumerable<SquareViewModel> Squares { get; }
        public RowViewModel(IEnumerable<SquareViewModel> squares, IGame game, int rowIndex)
        {
            Squares = squares;
        }
    }
}
