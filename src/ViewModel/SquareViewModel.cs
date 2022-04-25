using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Windows.Input;
using ViewModel.Command;

namespace ViewModel
{
    public class SquareViewModel
    {
        private ICell<bool> Enabled { get; set; }
        public SquareViewModel(ICell<IGame> game, Vector2D position)
        {
            Square = game.Derive(g => g.Board[position]);
            Enabled = game.Derive(g => g.IsSquareCovered(position) && g.Status == GameStatus.InProgress);

            Uncover = new UncoverSquareCommand(game, position, Enabled);
            Flag = new FlagSquareCommand(game, position, Enabled);
        }
        
        public ICell<Square> Square { get; }
        public ICommand Uncover { get; }

        public ICommand Flag { get; }
    }
}
