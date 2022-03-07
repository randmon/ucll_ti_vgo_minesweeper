using System.Collections.Generic;
using System.Windows;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var items = new List<string> { "a", "b", "c", "d", "e" };
            boardView.ItemsSource = items;
        }
    }
}
