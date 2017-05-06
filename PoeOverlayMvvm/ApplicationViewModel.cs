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
            CurrenciesObserver.InitCurrencies();
        }


    }
}
