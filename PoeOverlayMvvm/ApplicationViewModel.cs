using System.Collections.ObjectModel;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM;
using PoeOverlayMvvm.ViewModels;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {
        private RelayCommand _testCommand;

        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(parameter => {
            
        }));

        public ApplicationViewModel() {
        }

        public ItemSearchesPanel ItemSearchesPanel { get; set; } = new ItemSearchesPanel();
        public ItemsPanel ItemsPanel { get; set; } = new ItemsPanel();
    }
}
