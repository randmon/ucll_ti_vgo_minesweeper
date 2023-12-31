﻿using Model.MineSweeper;
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
            return status switch
            {
                SquareStatus.Covered => Covered,
                SquareStatus.Flagged => Flagged,
                SquareStatus.Mine => Mine,
                SquareStatus.Uncovered => Uncovered,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
