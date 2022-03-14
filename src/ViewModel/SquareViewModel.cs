using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel
    {
        public SquareViewModel(ICell<IGame> game, Vector2D position)
        {
            Square = game.Derive(g => g.Board[position]);
            Uncover = new UncoverSquareCommand(game, position);
        }

        public ICell<Square> Square { get; }
        public ICommand Uncover { get; }
    }
}
