using System;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model
{
    [JsonObject]
    public interface ISearchEngine
    {
        [JsonProperty]
        string Domain { get; set; }

        event Action<OfferedItem> OfferedItemFound;
    }
}
