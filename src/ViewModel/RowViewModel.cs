using Model.MineSweeper;

namespace ViewModel
{
    public class RowViewModel
    {
        public IEnumerable<Square> Squares { get; }
        public RowViewModel(IEnumerable<Square> squares)
        {
            Squares = squares;
        }
    }
}
