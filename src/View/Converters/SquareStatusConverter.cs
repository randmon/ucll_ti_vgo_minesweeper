using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters
{
    public class SquareStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SquareStatus status = (SquareStatus) value;
            switch (status)
            {
                case SquareStatus.Covered:
                    return Brushes.Transparent;
                case SquareStatus.Flagged:
                    return Brushes.Orange;
                case SquareStatus.Mine:
                    return Brushes.Black;
                case SquareStatus.Uncovered:
                    return Brushes.Transparent;
                default:
                    throw new ArgumentException("Invalid square status at converter");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
