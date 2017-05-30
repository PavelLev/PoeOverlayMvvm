using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Model.SearchEngine;
using PoeOverlayMvvm.ViewModels;

namespace PoeOverlayMvvm.Utility.MVVM.Designer {
    public static class DesignerDataContextObjects {
        public static Price DesignPrice { get; } =
            new Price {CurrencyShortName = "chaos", Quantity = -12};

        public static ItemSearch DesignItemSearch { get; } =
            new ItemSearch("Test ItemObserver", new DesignerSearchEngine(), DesignPrice, true);

        public static ItemSearchesPanel DesignItemSearchesPanel { get; } =
            new ItemSearchesPanel {
                ItemSearchesHistoryIsVisible = true,
                CurrentItemSearchesFilter = "1",
                OldItemSearchesFilter = "12"
            };

        public static ApplicationViewModel DesignViewModel { get; } =
            new ApplicationViewModel {ItemSearchesPanel = DesignItemSearchesPanel};

        public static Item DesignHeraldOfAshItem { get; } = new Item {
            Id = "dsafjqewurhiewdusfajl32747y",
            Name = "Herald of Ash",
            Buyout = DesignPrice,
            SellerId = "Test Seller Account 1",
            SellerAccountName = "Test Seller Account 1",
            SellerCharacterName = "Test Seller Character 1",
            StashTab = "sell 1",
            StashX = 2,
            StashY = 12,
            GemLevel = "19",
            Quality = "18",
            RequiredLevel = "64",
        };

        //uncompleted
        public static Item DesignDoomfletchPrismItem { get; } = new Item {
            Id = "qwerewdsjfi3485324y9r9uwerjfij",
            Name = "Doomfletch's Prism Royal Bow",
        };
    }
}
