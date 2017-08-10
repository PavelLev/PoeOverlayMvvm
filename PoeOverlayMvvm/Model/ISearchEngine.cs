using System;
using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.JsonConverters;

namespace PoeOverlayMvvm.Model
{
    [JsonConverter(typeof(SearchEngineJsonConverter))]
    public interface ISearchEngine {
        // by default search engine is initialized and stopped
        event Action<Item> OfferedItemFound;
        string Id { get; set; }
        void Initialize();
        void Start();
        void Stop();
    }
}
