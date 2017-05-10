using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class SearchItem: MyObservable {
        private string _name;
        private string _url;
        private double _price;
        private Currency _currency;
        private bool _autoWhisper;

        [JsonProperty]
        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }

        [JsonProperty]
        public string Url {
            get => _url;
            set => SetField(ref _url, value);
        }

        [JsonProperty]
        public double Price {
            get => _price;
            set => SetField(ref _price, value);
        }

        [JsonProperty]
        public Currency Currency {
            get => _currency;
            set => SetField(ref _currency, value);
        }

        [JsonProperty]
        public bool AutoWhisper {
            get => _autoWhisper;
            set => SetField(ref _autoWhisper, value);
        }

        [JsonConstructor]
        public SearchItem(string name, string url, double price, Currency currency, bool autoWhisper) {
            _name = name;
            _url = url;
            _price = price;
            _currency = currency;
            _autoWhisper = autoWhisper;
        }
    }
}
