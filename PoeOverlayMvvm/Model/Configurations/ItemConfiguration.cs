using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class ItemConfiguration {
        [JsonProperty]
        public IntervalConfiguration Interval { get; }

        [JsonProperty]
        public List<SearchItem> CurrentSearchItems { get; }

        [JsonProperty]
        public List<SearchItem> OldSearchItems { get; }
    }
}
