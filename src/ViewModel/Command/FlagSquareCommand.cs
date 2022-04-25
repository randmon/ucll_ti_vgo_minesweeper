using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModel.Command
{
    public class FlagSquareCommand : ICommand
    {
        public ICell<IGame> Game { get; }
        public Vector2D Position { get; }

        private ICell<bool> enabled { get; set; }

        public FlagSquareCommand(ICell<IGame> game, Vector2D position, ICell<bool> enabled)
        {
            Game = game;
            Position = position;
            this.enabled = enabled;
            enabled.ValueChanged += () => CanExecuteChanged?.Invoke(null, new EventArgs());
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return enabled.Value;
        }

        public void Execute(object? parameter)
        {
            Game.Value = Game.Value.ToggleFlag(Position);
        }
    }
}
