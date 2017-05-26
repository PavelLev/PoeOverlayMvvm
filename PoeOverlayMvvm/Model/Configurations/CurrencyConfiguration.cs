using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.JsonConverters;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class CurrencyConfiguration {
        [JsonProperty]
        public List<Currency> AllCurrencies { get; }

        [JsonProperty(ItemConverterType = typeof(PriceCurrenciesConverter))]
        public List<Currency> PriceCurrencies { get; }

        [JsonProperty]
        public int ApproximateValuePrecision { get; }

        [JsonProperty]
        public string CurrencyDomain { get; }

        [JsonProperty]
        public IntervalConfiguration Interval { get; }

        [JsonConstructor]
        public CurrencyConfiguration(List<Currency> allCurrencies, List<string> priceCurrencies, int approximateValuePrecision, string currencyDomain, IntervalConfiguration interval)
        {
            AllCurrencies = allCurrencies;
            PriceCurrencies = priceCurrencies.Select(priceCurrencyName => AllCurrencies.First(currency => currency.LongName == priceCurrencyName)).ToList();
            ApproximateValuePrecision = approximateValuePrecision;
            CurrencyDomain = currencyDomain;
            Interval = interval;
        }
    }
}
