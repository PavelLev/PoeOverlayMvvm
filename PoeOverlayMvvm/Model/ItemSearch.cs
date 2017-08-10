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

        [JsonProperty]
        public ISearchEngine SearchEngine { get; set; }

        [JsonProperty]
        public Price MaximumBuyout { get; set; }

        [JsonProperty]
        public bool AutoWhisper { get; set; }

        [JsonProperty]
        public bool IgnoreNoBuyout { get; set; }

        public static event Action<ItemSearch, Item> ItemFound;
        

        [JsonConstructor]
        public ItemSearch(string name, ISearchEngine searchEngine, Price maximumBuyout, bool autoWhisper, bool ignoreNoBuyout) {
            Name = name;
            SearchEngine = searchEngine;
            MaximumBuyout = maximumBuyout;
            AutoWhisper = autoWhisper;
            IgnoreNoBuyout = ignoreNoBuyout;

            SearchEngine.OfferedItemFound += item => {
                if (Configuration.Current.ItemConfiguration.SeenItemIds.Contains(item.Id)) {
                    return;
                }
                Configuration.Current.ItemConfiguration.SeenItemIds.Add(item.Id);

                if (IgnoreNoBuyout && item.Buyout.IsEmpty()) {
                    return;
                }

                if (item.Buyout.IsEmpty() || item.Buyout.ApproximateValue <= MaximumBuyout.ApproximateValue) {
                    ItemFound?.Invoke(this, item);
                }
            };
        }
    }
}
