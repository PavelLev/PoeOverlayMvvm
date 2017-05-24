using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;
using WebSocketSharp;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class ItemSearch: MyObservable {
        private string _name;
        private bool _autoWhisper;

        [JsonProperty]
        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }

        [JsonProperty]
        public ISearchEngine SearchEngine { get; set; }

        [JsonProperty]
        public Price MaximumBuyout { get; set; }

        [JsonProperty]
        public bool AutoWhisper {
            get => _autoWhisper;
            set => SetField(ref _autoWhisper, value);
        }
        
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
