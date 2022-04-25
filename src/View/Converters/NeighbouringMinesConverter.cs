using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    internal class NeighbouringMinesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mineCount = (int)value;
            switch (mineCount)
            {
                case 0:
                    return "";
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
