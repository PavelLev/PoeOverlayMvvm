using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using PoeOverlayMvvm.Utility.MVVM.CommandParameters;

namespace PoeOverlayMvvm.Utility.MVVM.Converters {
    public class ProcessSearchParametersConverter : MarkupExtension, IMultiValueConverter {
        private ProcessSearchParametersConverter _instance;

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture) {
            return new ProcessSearchParameters {
                SearchString = (string) value[0],
                ItemsControl = (ItemsControl) value[1],
                ItemMatchesSearchString = (Func<object, string, bool>) value[2]
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return _instance ?? (_instance = new ProcessSearchParametersConverter());
        }
    }
}
