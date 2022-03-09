using Model.MineSweeper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    public class SquareStatusConverter : IValueConverter
    {
        public object Uncovered { get; set; }
        public object Covered { get; set; }
        public object Flagged { get; set; }
        public object Mine { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SquareStatus status = (SquareStatus)value;
            switch (status)
            {
                case SquareStatus.Covered:
                    return Covered;
                case SquareStatus.Flagged:
                    return Flagged;
                case SquareStatus.Mine:
                    return Mine;
                case SquareStatus.Uncovered:
                    return Uncovered;
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
