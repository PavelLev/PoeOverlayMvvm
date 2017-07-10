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
        
        public ObservableCollection<Item> CurrentItems { get; }
        
        public ObservableCollection<Item> OldItems { get; }

        [JsonConstructor]
        public ItemConfiguration(ObservableCollection<ItemSearch> currentSearchItems, ObservableCollection<ItemSearch> oldSearchItems, ObservableCollection<Item> currentOfferedItems, ObservableCollection<Item> oldOfferedItems) {
            CurrentItemSearches = currentSearchItems ?? new ObservableCollection<ItemSearch>();
            // by default search engine is initialized and stopped
            foreach (var currentSearchItem in CurrentItemSearches) {
                currentSearchItem.SearchEngine.Start();
            }
            OldItemSearches = oldSearchItems ?? new ObservableCollection<ItemSearch>();
            CurrentItems = new ObservableCollection<Item> {DesignerDataContextObjects.DesignHeraldOfAshItem, DesignerDataContextObjects.DesignDoomfletchPrismItem, DesignerDataContextObjects.BloodStrapCrystalBelt, DesignerDataContextObjects.BroodClaspCrystalBelt};
            OldItems = new ObservableCollection<Item>();
        }
    }
}
