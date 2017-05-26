using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class ItemConfiguration {
        [JsonProperty]
        public ObservableCollection<ItemSearch> CurrentSearchItems { get; }

        [JsonProperty]
        public ObservableCollection<ItemSearch> OldSearchItems { get; }

        [JsonProperty]
        public ObservableCollection<Item> CurrentOfferedItems { get; }

        [JsonProperty]
        public ObservableCollection<Item> OldOfferedItems { get; }
    }
}
