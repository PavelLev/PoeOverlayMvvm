﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class ItemConfiguration {
        [JsonProperty]
        public IntervalConfiguration Interval { get; }

        [JsonProperty]
        public ObservableCollection<SearchItem> CurrentSearchItems { get; }

        [JsonProperty]
        public ObservableCollection<SearchItem> OldSearchItems { get; }

        [JsonProperty]
        public ObservableCollection<OfferedItem> CurrentOfferedItems { get; }

        [JsonProperty]
        public ObservableCollection<OfferedItem> OldOfferedItems { get; }
    }
}
