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

            GameViewModel gameViewModel = new GameViewModel(game);
            this.DataContext = gameViewModel;
        }        
    }
}
