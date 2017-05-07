using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm {
    public sealed class ApplicationViewModel: MyObservable {

        public bool ShowOnOffer { get; set; }

        public ObservableCollection<Observer> Observers { get; }

        public ObservableCollection<Offer> Offers { get; }

        public ApplicationViewModel() {
            //without it designer throws exception
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                Configuration.Load();
            }
            CurrenciesObserver.InitCurrencies();
        }


    }
}
