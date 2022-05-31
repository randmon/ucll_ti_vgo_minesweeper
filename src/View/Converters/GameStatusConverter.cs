using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class GameStatusConverter : IValueConverter
    {
        public object InProgress { get; set; }
        public object Won { get; set; }
        public object Lost { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameStatus status = (GameStatus)value;
            return status switch
            {
                GameStatus.InProgress => InProgress,
                GameStatus.Won => Won,
                GameStatus.Lost => Lost,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
