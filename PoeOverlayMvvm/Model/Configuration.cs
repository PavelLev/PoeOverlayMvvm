using System.Collections.Generic;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.Configurations;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class Configuration {
        public static Configuration Current { get; private set; }
        private static readonly string Path = "Resources\\configuration.json";

        public static void Load() {
            Current = Current ?? JsonSerializerExtension.Serializer.DeserializeFromFile<Configuration>(Path);
        }

        [JsonProperty]
        public string LeagueName { get; }
        
        [JsonProperty]
        public List<string> TargetTitles { get; }

        [JsonProperty]
        public int TextBoxDelay { get; }

        [JsonProperty]
        public CurrencyConfiguration CurrencyConfiguration { get; }

        [JsonProperty]
        public ItemConfiguration ItemConfiguration { get; }

        [JsonConstructor]
        public Configuration(string leagueName, List<string> targetTitles, int textBoxDelay, CurrencyConfiguration currencyConfiguration, ItemConfiguration itemConfiguration) {
            LeagueName = leagueName;
            TargetTitles = targetTitles;
            TextBoxDelay = textBoxDelay;
            CurrencyConfiguration = currencyConfiguration;
            ItemConfiguration = itemConfiguration;
        }
    }
}
