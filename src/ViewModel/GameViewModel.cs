using Model.Data;
using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {
        private readonly IGame _game;
        public GameViewModel(IGame game)
        {
            _game = game;
            Rows = GetRows();
         }

        public IEnumerable<IEnumerable<Square>> Rows { get; }

        public IEnumerable<IEnumerable<Square>> GetRows()
        {
            List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();
            for (int i = 0; i < _game.Board.Height; i++)
            {
                result.Add(Row(i));
            }
            return result;
        }


        public IEnumerable<Square> Row(int row)
        {
            List<Square> result = new List<Square>();
            for (int i = 0; i < _game.Board.Width; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(_game.Board[position]);
            }
            return result;
        }
    }
}
