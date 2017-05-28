using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.JsonConverters;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class CurrencyConfiguration {
        [JsonProperty]
        public List<Currency> AllCurrencies { get; }

        [JsonProperty]
        public List<string> PriceCurrencyLongNames { get; }

        [JsonProperty]
        public int ApproximateValuePrecision { get; }

        [JsonProperty]
        public string CurrencyDomain { get; }

        [JsonProperty]
        public IntervalConfiguration Interval { get; }

        [JsonConstructor]
        public CurrencyConfiguration(List<Currency> allCurrencies, List<string> priceCurrencyLongNames, int approximateValuePrecision, string currencyDomain, IntervalConfiguration interval)
        {
            AllCurrencies = allCurrencies;
            PriceCurrencyLongNames = priceCurrencyLongNames;
            ApproximateValuePrecision = approximateValuePrecision;
            CurrencyDomain = currencyDomain;
            Interval = interval;
        }
    }
}
