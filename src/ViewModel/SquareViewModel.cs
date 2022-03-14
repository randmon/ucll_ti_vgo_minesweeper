using Model.MineSweeper;

namespace ViewModel
{
    public class SquareViewModel
    {
        public Square Square { get; }
        public SquareViewModel(Square square)
        {
            Square = square;
        }
    }
}
