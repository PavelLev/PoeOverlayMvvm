using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public sealed class MultiplyConverter : MarkupExtension, IValueConverter {
        private static MultiplyConverter _instance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _instance ?? (_instance = new MultiplyConverter());
        }
    }
}
