using System.Text;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model.Item
{
    [JsonObject]
    public class Price : MyObservable
    {
        private double _quantity;
        private Currency _currency;

        [JsonProperty]
        public double Quantity {
            get => _quantity;
            set => SetField(ref _quantity, value);
        }

        [JsonProperty]
        public Currency Currency {
            get => _currency;
            set => SetField(ref _currency, value);
        }

        public double ApproximateValue => Quantity * Currency.ApproximateValue;

        public string ToShortString() {
            return new StringBuilder(Quantity.ToString())
                .Append(Currency.ShortName)
                .ToString();
        }
    }
}
