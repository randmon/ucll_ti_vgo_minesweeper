using Model.Data;
using Model.MineSweeper;
using System.Collections.Generic;
using System.Windows;
using ViewModel;

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

            game = game.UncoverSquare(new Vector2D(0, 0));
            game = game.ToggleFlag(new Vector2D(2, 0));
            game = game.UncoverSquare(new Vector2D(3, 0)); //Uncover with bomb, ends game!

            GameViewModel gameViewModel = new GameViewModel(game);
            this.DataContext = gameViewModel;
        }        
    }
}
