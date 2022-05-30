using Cells;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(Settings settings)
        {
            Settings = settings;
            Game = Cell.Create(IGame.CreateRandom(settings.Size, settings.MineProbability, settings.Flooding));
            
            Board = new GameBoardViewModel(this);
            Status = Game.Derive(g => g.Status);
            FirstClick = true;
        }

        public GameBoardViewModel Board { get; }
        public ICell<IGame> Game { get; set; }
        public ICell<GameStatus> Status { get; set; }
        public bool FirstClick { get; set; }
        public Settings Settings { get; set; }
    }
}
