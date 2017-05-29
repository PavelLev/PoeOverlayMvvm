using System.Collections.Generic;
using Newtonsoft.Json;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model.Configurations;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class Configuration {
        public static Configuration Current { get; private set; }
        private static string _path = "configuration.json";

        static Configuration() {
            Load();
        }

        public static void Load() {
            if (Current != null) {
                return;
            }

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) {
                _path = "D:\\PoE\\projects\\PoeOverlayMvvm\\PoeOverlayMvvm\\designerConfiguration.json";
            }

            Current = JsonSerializerExtension.Serializer.DeserializeFromFile<Configuration>(_path);

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) {
                return;
            }

            AllCurrenciesObserver.Load();
            ItemSearchUdpServer.Load();
        }

        //TODO Save + autosave

        [JsonProperty]
        public bool ShowOnOffer { get; set; }

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
        public Configuration(bool showOnOffer, string leagueName, List<string> targetTitles, int textBoxDelay, CurrencyConfiguration currencyConfiguration, ItemConfiguration itemConfiguration) {
            ShowOnOffer = showOnOffer;
            LeagueName = leagueName;
            TargetTitles = targetTitles;
            TextBoxDelay = textBoxDelay;
            CurrencyConfiguration = currencyConfiguration;
            ItemConfiguration = itemConfiguration;
        }
    }
}
