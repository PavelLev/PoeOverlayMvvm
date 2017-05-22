using System.Collections.Generic;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.Configurations;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class Configuration : MyObservable {
        public static Configuration Current { get; private set; }
        private static readonly string Path = "configuration.json";
        private bool _showOnOffer;

        public static void Load() {
            Current = Current ?? JsonSerializerExtension.Serializer.DeserializeFromFile<Configuration>(Path);
        }

        //TODO Save + autosave

        [JsonProperty]
        public bool ShowOnOffer {
            get => _showOnOffer;
            set => SetField(ref _showOnOffer, value);
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
    }
}
