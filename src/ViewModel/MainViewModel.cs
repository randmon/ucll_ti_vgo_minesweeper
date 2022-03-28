using Cells;
using Model.MineSweeper;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CurrentScreen = Cell.Create<ScreenViewModel>(null);
            var firstScreen = new GameScreenViewModel(CurrentScreen);
            CurrentScreen.Value = firstScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }

    public abstract class ScreenViewModel
    {
        protected ScreenViewModel(ICell<ScreenViewModel> currentScreen)
        {
            this.CurrentScreen = currentScreen;
        }

        protected ICell<ScreenViewModel> CurrentScreen { get; }
    }

    public class GameScreenViewModel : ScreenViewModel
    {
        public GameScreenViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            var game = IGame.Parse(new List<string> {
              "..**.",
              ".....",
              ".....",
              ".***.",
              ".***."
            });

            Game = new GameViewModel(game);

            ShowSettings = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(this.CurrentScreen));
        }

        public GameViewModel Game { get; }

        public ICommand ShowSettings { get; }
    }

    public class SettingsScreenViewModel : ScreenViewModel
    {
        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            ShowGame = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen));
        }
        public ICommand ShowGame { get; }

    }

    public class ActionCommand : ICommand
    {
        private readonly Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}

