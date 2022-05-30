using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModel.Command
{
    public class UncoverSquareCommand : ICommand
    {
        private ICell<bool> Enabled { get; set; }
        private GameViewModel GameViewModel { get; set; }
        public ICell<IGame> Game { get; }
        public Vector2D Position { get; }

        public UncoverSquareCommand(GameViewModel gameViewModel, Vector2D position, ICell<bool> enabled)
        {
            GameViewModel = gameViewModel;
            Game = gameViewModel.Game;
            Position = position;
            Enabled = enabled;
            enabled.ValueChanged += () => CanExecuteChanged?.Invoke(null, new EventArgs());
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return Enabled.Value;
        }

        public void Execute(object? parameter)
        {
            if (Game.Value.Status == GameStatus.InProgress)
            {

                if (GameViewModel.FirstClick)
                {
                    while (true)
                    {
                        // Check if the first click is on a mine
                        if (Game.Value.UncoverSquare(Position).Status == GameStatus.Lost)
                        {
                            Debug.WriteLine("You lost, generating new game...");
                            // Generate a new game
                            Settings s = GameViewModel.Settings;
                            Game.Value = IGame.CreateRandom(s.Size, s.MineProbability, s.Flooding);
                        }
                        else
                        {
                            Debug.WriteLine("You didn't lose yet");
                            Game.Value = Game.Value.UncoverSquare(Position);
                            break;
                        }
                    }
                    GameViewModel.FirstClick = false;
                }
                else
                {
                    Game.Value = Game.Value.UncoverSquare(Position);
                }
            }
        }
    }
}
