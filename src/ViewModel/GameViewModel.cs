using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(IGame game)
        {
            Board = new GameBoardViewModel(game);
        }

        public GameBoardViewModel Board { get; }
    }
}
