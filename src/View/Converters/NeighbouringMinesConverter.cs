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
            return mineCount switch
            {
                0 => "",
                _ => value,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
