using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class ElementInIListConverter : MarkupExtension, IMultiValueConverter {
        private ElementInIListConverter _instance;

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) {
            return ((IList)value[1]).Contains(value[0]);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _instance ?? (_instance = new ElementInIListConverter());
        }
    }
}
