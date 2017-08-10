using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public sealed class StringContainsStringConverter : IMultiValueConverter {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) {

            if (!(value[1] is string)) { //designer passes MS.Internal.NamedObject {"_name":"DependencyProperty.UnsetValue"}
                return false;
            }

            return ((string)value[0]).Contains((string)value[1]);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
