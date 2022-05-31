using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    internal class NeighbouringMinesConverter : IValueConverter
    {
        public object M0 { get; set; }
        public object M1 { get; set; }
        public object M2 { get; set; }
        public object M3 { get; set; }
        public object M4 { get; set; }
        public object M5 { get; set; }
        public object M6 { get; set; }
        public object M7 { get; set; }
        public object M8 { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mineCount = (int)value;
            return mineCount switch
            {
                0 => M0,
                1 => M1,
                2 => M2,
                3 => M3,
                4 => M4,
                5 => M5,
                6 => M6,
                7 => M7,
                8 => M8,
                _ => new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
