using Model.Data;
using Model.MineSweeper;
using System.Collections.Generic;
using System.Windows;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*var game = IGame.Parse(new List<string> {
              "..........",
              ".*....*...",
              "..........",
              "...*....*.",
              "**...**...",
              "..........",
              ".*....*...",
              "..........",
              "...*....*.",
              "**...**..."
            });*/

            var game = IGame.Parse(new List<string> {
              "..**.",
              ".....",
              ".....",
              ".***.",
              ".***."
            });

            game = game.UncoverSquare(new Vector2D(1, 0));
            game = game.ToggleFlag(new Vector2D(2, 0));
            game = game.UncoverSquare(new Vector2D(3, 0)); //Uncover with bomb, ends game!

            this.boardView.ItemsSource = Rows(game.Board);
        }

        public IEnumerable<Square> Row(IGameBoard board, int row)
        {
            List<Square> result = new List<Square>();
            for (int i = 0; i < board.Height; i++)
            {
                var position = new Vector2D(i, row);
                result.Add(board[position]);
            }
            return result;
        }

        public IEnumerable<IEnumerable<Square>> Rows(IGameBoard board)
        {
            List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();
            for (int i = 0; i < board.Width; i++)
            {
                result.Add(Row(board, i));
            }
            return result;
        }
    }
}
