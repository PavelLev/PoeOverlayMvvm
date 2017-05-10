using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class ObserverIntervalConverter : MarkupExtension, IValueConverter {
        private static ObserverIntervalConverter _instance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return System.Convert.ToInt32(value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return int.TryParse((string)value, out var result)
                ? result
                : 0;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _instance ?? (_instance = new ObserverIntervalConverter());
        }
    }
}
