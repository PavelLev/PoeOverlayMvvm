﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class ObserverIntervalConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return int.TryParse((string)value, out var result)
                ? result
                : 0;
        }
    }
}
