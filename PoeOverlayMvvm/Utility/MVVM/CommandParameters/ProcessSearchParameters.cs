using System;
using System.Windows.Controls;

namespace PoeOverlayMvvm.Utility.MVVM.CommandParameters {
    public class ProcessSearchParameters {
        public string SearchString { get; set; }
        public ItemsControl ItemsControl { get; set; }

        public Func<object, string, bool> ItemMatchesSearchString { get; set; }
    }
}
