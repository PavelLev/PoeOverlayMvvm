using System.Collections.ObjectModel;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {
        private RelayCommand _testCommand;

        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(parameter => {
            
        }));

        public ApplicationViewModel() {
        }

        public bool ItemSearchesHistoryIsVisible { get; set; } = false;

        public string CurrentItemSearches { get; set; } = "";
    }
}
