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
            var firstScreen = new SettingsScreenViewModel(CurrentScreen, new Settings());
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
        private Settings Settings { get; set; }
        public GameScreenViewModel(ICell<ScreenViewModel> currentScreen, Settings settings) : base(currentScreen)
        {
            Settings = settings;
            Game = new GameViewModel(Settings);
            ShowSettings = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(CurrentScreen, settings));
        }

        public GameViewModel Game { get; }
        public ICommand ShowSettings { get; }
    }

    public class SettingsScreenViewModel : ScreenViewModel
    {
        public Settings Settings;
        public ICell<int> Size { get; set; }
        public ICell<int> MineProbability { get; set; }
        public ICell<bool> Flooding { get; set; }
        public int MaxSize { get; }
        public int MinSize { get; }

        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen, Settings settings) : base(currentScreen)
        {
            if (settings == null)
            {
                Settings = new Settings();
            } else
            {
                Settings = settings;

            }
            Size = Cell.Create<int>(Settings.Size);
            MineProbability = Cell.Create<int>((int)(Settings.MineProbability * 100));
            Flooding = Cell.Create<bool>(Settings.Flooding);
            this.MaxSize = IGame.MaximumBoardSize;
            this.MinSize = IGame.MinimumBoardSize;

            ShowGame = new ActionCommand(StartGame);
        }
        public ICommand ShowGame { get; }

        private void StartGame()
        {
            // Save settings
            Settings.Size = Size.Value;
            Settings.MineProbability = MineProbability.Value / 100.0;
            Settings.Flooding = Flooding.Value;
            
            // Change screen
            CurrentScreen.Value = new GameScreenViewModel(CurrentScreen, Settings);
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

