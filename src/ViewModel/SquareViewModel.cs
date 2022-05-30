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
        public SquareViewModel(GameViewModel gameViewModel, Vector2D position)
        {
            GameViewModel = gameViewModel;
            ICell<IGame> game = gameViewModel.Game;
            Square = game.Derive(g => g.Board[position]);
            Enabled = game.Derive(g => g.IsSquareCovered(position));
            Status = game.Derive(g =>
            {
                if (g.Status == GameStatus.Lost && g.Mines.Contains(position))
                {
                    return SquareStatus.Mine;
                } else
                {
                    return g.Board[position].Status;
                }
            });

            Uncover = new UncoverSquareCommand(gameViewModel, position, Enabled);
            Flag = new FlagSquareCommand(game, position, Enabled);
        }
        
        public ICell<Square> Square { get; }
        public ICommand Uncover { get; }
        public ICommand Flag { get; }

        public GameViewModel GameViewModel { get; }
        public ICell<SquareStatus> Status { get; set; }
    }
}
