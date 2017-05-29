using System.Collections.ObjectModel;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {
        private RelayCommand _testCommand;
        private bool _itemSearchesHistoryIsVisible = true;
        private string _currentItemSearchesFilter = "1";
        private string _oldItemSearchesFilter = "12";

        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(parameter => {
            
        }));

        public ApplicationViewModel() {
        }

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
