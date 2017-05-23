﻿using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Logic
{
    public static class SearchItemsInteraction {
        public static void Initialize() {
            ItemSearch.OfferedItemFound += (searchItem, offeredItem) => {
                Configuration.Current.ItemConfiguration.CurrentOfferedItems.Add(offeredItem);
                if (searchItem.AutoWhisper) {
                    offeredItem.SendWhisper();
                }
            };
        }
    }
}
