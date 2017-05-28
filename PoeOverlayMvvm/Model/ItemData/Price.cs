using System.Text;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model.ItemData {
    [JsonObject]
    public class Price : MyObservable
    {
        private double _quantity;
        private string _currencyShortName;

        [JsonProperty]
        public double Quantity {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }

        [JsonProperty]
        public string CurrencyShortName {
            get => _currencyShortName;
            set => SetField(ref _currencyShortName, value);
        }

        public double ApproximateValue => Quantity * Currency.ByShortName(CurrencyShortName).ApproximateValue;
        
    }
}
