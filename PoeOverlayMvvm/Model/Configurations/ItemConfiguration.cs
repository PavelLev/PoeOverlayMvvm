using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class ItemConfiguration {
        [JsonProperty]
        public IntervalConfiguration Interval { get; }


        [JsonConstructor]
        public ItemConfiguration(IntervalConfiguration interval) {
            Interval = interval;
        }
    }
}
