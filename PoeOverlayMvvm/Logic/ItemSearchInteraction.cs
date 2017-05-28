﻿using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Logic
{
    public static class ItemSearchInteraction {
        public static void Initialize() {
            ItemSearch.OfferedItemFound += (searchItem, offeredItem) => {
                Configuration.Current.ItemConfiguration.CurrentItems.Add(offeredItem);
                if (searchItem.AutoWhisper) {
                    offeredItem.SendWhisper();
                }
            };
        }
    }
}
