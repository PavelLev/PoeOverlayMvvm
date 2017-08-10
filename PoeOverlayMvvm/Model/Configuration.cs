using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using Newtonsoft.Json;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model.Configurations;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class Configuration {
        public static Configuration Current { get; private set; }
        //private static string _path = "D:\\PoE\\projects\\PoeOverlayMvvm\\PoeOverlayMvvm\\designerConfiguration.json";
        private static string _path = "./configuration.json";
        

        public static void Load() {
            if (Current != null) {
                return;
            }

            Current = File.Exists(_path)
                ? JsonSerializerExtension.Serializer.DeserializeFromFile<Configuration>(_path)
                : JsonSerializerExtension.Serializer.DeserializeFromStream<Configuration>(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("PoeOverlayMvvm.Resources.configuration.json"));
        }

        public static void Save() {
            if (Current == null) {
                return;
            }

            JsonSerializerExtension.Serializer.SerializeToFile(_path, Current);
        }

        //TODO Save + autosave

        [JsonProperty]
        public bool ShowOnOffer { get; set; }

        [JsonProperty]
        public string LeagueName { get; set; }
        
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
            foreach (var currentSearchItem in itemConfiguration.CurrentItemSearches)
            {
                currentSearchItem.SearchEngine.Start();
            }
        }
    }
}
