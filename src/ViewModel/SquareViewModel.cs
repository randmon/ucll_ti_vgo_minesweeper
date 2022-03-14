using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        public Square Square { get; }
        public SquareViewModel(Square square)
        {
            Square = square;
            Uncover = new UncoverSquareCommand();
        }

        public ICommand Uncover { get; }
    }
}
