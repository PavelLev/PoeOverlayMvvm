using System.Linq;
using Newtonsoft.Json;

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
        public double OfferedValue { get; set; } = 0;

        [JsonProperty]
        public double RequestedValue { get; set; } = 0;


        public double ApproximateValue => (OfferedValue + RequestedValue) / 
            (OfferedValue == 0 || RequestedValue == 0 ? 1 : 2);

        public static Currency ByName(string name) {
            return Configuration.Current.CurrencyConfiguration.AllCurrencies.First(currency => currency.Name == name);
        }

        public static Currency ByShortName(string shortName)
        {
            return Configuration.Current.CurrencyConfiguration.AllCurrencies.First(currency => currency.ShortName == shortName);
        }
    }
}
