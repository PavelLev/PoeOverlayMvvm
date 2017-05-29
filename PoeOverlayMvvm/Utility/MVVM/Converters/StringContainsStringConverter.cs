using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public sealed class StringContainsStringConverter : MarkupExtension, IMultiValueConverter {
        private static StringContainsStringConverter _instance;

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) {
            return ((string) value[0]).Contains((string) value[1]);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _instance ?? (_instance = new StringContainsStringConverter());
        }
    }
}
