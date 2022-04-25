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
            var firstScreen = new SettingsScreenViewModel(CurrentScreen);
            CurrentScreen.Value = firstScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }

    public abstract class ScreenViewModel
    {
        protected ScreenViewModel(ICell<ScreenViewModel> currentScreen)
        {
            CurrentScreen = currentScreen;
        }

        protected ICell<ScreenViewModel> CurrentScreen { get; }
    }

    public class GameScreenViewModel : ScreenViewModel
    {
        public GameScreenViewModel(ICell<ScreenViewModel> currentScreen, IGame game) : base(currentScreen)
        {
            Game = new GameViewModel(game);

            ShowSettings = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(this.CurrentScreen));
        }

        public GameViewModel Game { get; }

        public ICommand ShowSettings { get; }
    }

    public class SettingsScreenViewModel : ScreenViewModel
    {
        public ICell<int> Width { get; }
        public ICell<bool> Flooding { get; }

        public int MaxSize { get; }
        public int MinSize { get; }

        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            this.Width = Cell.Create<int>(10);
            this.Flooding = Cell.Create<bool>(true);

            this.MaxSize = IGame.MaximumBoardSize;
            this.MinSize = IGame.MinimumBoardSize;

            ShowGame = new ActionCommand(startGame);
        }
        public ICommand ShowGame { get; }

        private void startGame()
        {
            double mineProbability = 0.1;
            var game = IGame.CreateRandom(Width.Value, mineProbability, Flooding.Value);
            CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, game);
        }

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

