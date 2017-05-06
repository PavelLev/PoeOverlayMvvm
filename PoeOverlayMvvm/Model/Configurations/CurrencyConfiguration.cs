using System.Collections.Generic;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.JsonConverters;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class CurrencyConfiguration {
        [JsonProperty]
        public List<Currency> AllCurrencies { get; }

        [JsonProperty]
        public List<Currency> PriceCurrencies { get; }

        [JsonProperty]
        public int ApproximateValuePrecision { get; }

        [JsonProperty]
        public string CurrencyDomain { get; }

        [JsonProperty]
        public IntervalConfiguration Interval { get; }

        [JsonProperty]
        private string AllCurrenciesFilePath { get; }

        [JsonProperty(ItemConverterType = typeof(PriceCurrenciesConverter))]
        private string PriceCurrenciesFilePath { get; }

        [JsonConstructor]
        public CurrencyConfiguration(List<Currency> allCurrencies, List<Currency> priceCurrencies, int approximateValuePrecision, string currencyDomain, IntervalConfiguration interval, string allCurrenciesFilePath, string priceCurrenciesFilePath) {
            AllCurrencies = allCurrencies;
            PriceCurrencies = priceCurrencies;
            ApproximateValuePrecision = approximateValuePrecision;
            CurrencyDomain = currencyDomain;
            Interval = interval;
            AllCurrenciesFilePath = allCurrenciesFilePath;
            PriceCurrenciesFilePath = priceCurrenciesFilePath;
        }
    }
}
