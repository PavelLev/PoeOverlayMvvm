using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class ElementInIListConverter : IMultiValueConverter {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value[1] is IList)) { //designer passes MS.Internal.NamedObject {"_name":"DependencyProperty.UnsetValue"}
                return false;
            }
            return ((IList)value[1]).Contains(value[0]);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
