using Model.MineSweeper;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModel
{
    internal class UncoverSquareCommand : ICommand
    {
        public IGame Game { get; }
        public UncoverSquareCommand(IGame game)
        {
            Game = game;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Debug.WriteLine("You clicked me");
        }
    }
}
