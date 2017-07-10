using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.ViewModels {
    public class ItemsPanel : MyObservable {
        private bool _itemsHistoryIsVisible;
        private string _currentItemsFilter = "";
        private string _oldItemsFilter = "";

        public bool ItemsHistoryIsVisible {
            get => _itemsHistoryIsVisible;
            set => SetField(ref _itemsHistoryIsVisible, value);
        }

        public string CurrentItemsFilter {
            get => _currentItemsFilter;
            set => SetField(ref _currentItemsFilter, value);
        }

        public string OldItemsFilter {
            get => _oldItemsFilter;
            set => SetField(ref _oldItemsFilter, value);
        }
    }
}
