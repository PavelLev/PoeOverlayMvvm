using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class MultiConverterChain : List<object>, IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return this.Skip(1)
                .Aggregate(((IMultiValueConverter) this[0]).Convert(values, targetType, parameter, culture),
                    (current, converter) => ((IValueConverter) converter).Convert(current, targetType, parameter,
                        culture));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
