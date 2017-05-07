using System.Linq;
using Newtonsoft.Json;
using PoeOverlayMvvm.Logic;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class Currency {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string ShortName { get; set; }
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public double ApproximateValue { get; set; }


        public static Currency ByName(string name) {
            return Configuration.Current.CurrencyConfiguration.AllCurrencies.First(currency => currency.Name == name);
        }

        public static implicit operator Currency(string name)
        {
            return Configuration.Current.CurrencyConfiguration.AllCurrencies.First(currency => currency.Name == name);
        }

        public static explicit operator string(Currency currency)
        {
            return currency.Name;
        }
    }
}
