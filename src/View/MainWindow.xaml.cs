using System.Collections.Generic;
using System.Windows;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var row1 = new List<string> { "a", "b", "c", "d", "e" };
            var row2 = new List<string> { "e", "f", "g", "h", "i" };
            var row3 = new List<string> { "j", "k", "l", "m", "n" };
            var grid = new List<List<string>> { row1, row2, row3 };

            this.boardView.ItemsSource = grid;
        }
    }
}
