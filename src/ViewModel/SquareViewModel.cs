using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        public Square Square { get; }
        public SquareViewModel(Square square, IGame game)
        {
            Square = square;
            Uncover = new UncoverSquareCommand(game);
        }

        public ICommand Uncover { get; }
    }
}
