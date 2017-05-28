using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class ItemConfiguration {
        [JsonProperty]
        public ObservableCollection<ItemSearch> CurrentItemSearches { get; }

        [JsonProperty]
        public ObservableCollection<ItemSearch> OldItemSearches { get; }

        [JsonProperty]
        public ObservableCollection<Item> CurrentItems { get; }

        [JsonProperty]
        public ObservableCollection<Item> OldItems { get; }

        [JsonConstructor]
        public ItemConfiguration(ObservableCollection<ItemSearch> currentSearchItems, ObservableCollection<ItemSearch> oldSearchItems, ObservableCollection<Item> currentOfferedItems, ObservableCollection<Item> oldOfferedItems) {
            CurrentItemSearches = currentSearchItems ?? new ObservableCollection<ItemSearch>();
            // by default search engine is initialized and stopped
            foreach (var currentSearchItem in CurrentItemSearches) {
                currentSearchItem.SearchEngine.Start();
            }
            OldItemSearches = oldSearchItems ?? new ObservableCollection<ItemSearch>();
            CurrentItems = currentOfferedItems ?? new ObservableCollection<Item>();
            OldItems = oldOfferedItems ?? new ObservableCollection<Item>();
        }
    }
}
