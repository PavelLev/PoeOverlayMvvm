using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.ViewModels {
    public class ItemSearchesPanel : MyObservable{
        private bool _itemSearchesHistoryIsVisible;
        private string _currentItemSearchesFilter = "";
        private string _oldItemSearchesFilter = "";

        public bool ItemSearchesHistoryIsVisible {
            get => _itemSearchesHistoryIsVisible;
            set => SetField(ref _itemSearchesHistoryIsVisible, value);
        }

        public string CurrentItemSearchesFilter {
            get => _currentItemSearchesFilter;
            set => SetField(ref _currentItemSearchesFilter, value);
        }

        public string OldItemSearchesFilter {
            get => _oldItemSearchesFilter;
            set => SetField(ref _oldItemSearchesFilter, value);
        }
    }
}
