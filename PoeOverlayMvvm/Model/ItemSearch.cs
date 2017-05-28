using System;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Utility.JsonConverters;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class ItemSearch: MyObservable {
        [JsonProperty]
        public string Name { get; set; }

        [JsonConverter(typeof(SearchEngineJsonConverter))]
        public ISearchEngine SearchEngine { get; set; }

        [JsonProperty]
        public Price MaximumBuyout { get; set; }

        [JsonProperty]
        public bool AutoWhisper { get; set; }

        public static event Action<ItemSearch, Item> OfferedItemFound;
        

        [JsonConstructor]
        public ItemSearch(string name, ISearchEngine searchEngine, Price maximumBuyout, bool autoWhisper) {
            Name = name;
            SearchEngine = searchEngine;
            MaximumBuyout = maximumBuyout;
            AutoWhisper = autoWhisper;

            SearchEngine.OfferedItemFound += offeredItem => {
                if (offeredItem.Buyout == null || offeredItem.Buyout.ApproximateValue <=
                    MaximumBuyout.ApproximateValue) {
                    OfferedItemFound?.Invoke(this, offeredItem);
                }
            };
        }
    }
}
