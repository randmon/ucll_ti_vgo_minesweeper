using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        public Square Square { get; }
        public SquareViewModel(IGame game, Vector2D position)
        {
            Square = game.Board[position];
            Uncover = new UncoverSquareCommand(game, position);
        }

        public ICommand Uncover { get; }
    }
}
