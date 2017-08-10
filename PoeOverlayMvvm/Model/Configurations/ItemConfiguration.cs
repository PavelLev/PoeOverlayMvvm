using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM.Designer;

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

        [JsonProperty]
        public List<string> SeenItemIds { get; }

        public ItemConfiguration(ObservableCollection<ItemSearch> currentSearchItems, ObservableCollection<ItemSearch> oldSearchItems, ObservableCollection<Item> currentItems, ObservableCollection<Item> oldItems, List<string> seenItemIdList)
        {

            CurrentItemSearches = currentSearchItems ?? new ObservableCollection<ItemSearch>();
            // by default search engine is initialized and stopped
            OldItemSearches = oldSearchItems ?? new ObservableCollection<ItemSearch>();
            CurrentItems = currentItems ?? new ObservableCollection<Item>();
            OldItems = oldItems ?? new ObservableCollection<Item>();
            SeenItemIds = seenItemIdList ?? new List<string>();
        }
    }
}
