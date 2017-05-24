using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.ItemData {
    [JsonObject]
    public class PostResponse
    {
        [JsonProperty]
        public int Count { get; set; }
        [JsonProperty]
        public string Data { get; set; }
        [JsonProperty]
        public int NewId { get; set; }
    }
}
