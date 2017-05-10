using System.Collections.ObjectModel;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {
        private RelayCommand _testCommand;

        public RelayCommand TestCommand => _testCommand ?? (_testCommand = new RelayCommand(parameter => {
            
        }));

        public ObservableCollection<SearchItem> Observers { get; }

        public ObservableCollection<Offer> Offers { get; }

        public ApplicationViewModel() {
            //without it designer throws exception
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                Configuration.Load();
            }
            AllCurrenciesObserver.InitCurrencies();
        }


    }
}
