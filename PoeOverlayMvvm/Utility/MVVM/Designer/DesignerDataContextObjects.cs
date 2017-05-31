using System.Collections.Generic;
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
        
        public static Item DesignDoomfletchPrismItem { get; } = new Item {
            Id = "qwerewdsjfi3485324y9r9uwerjfij",
            Name = "Doomfletch's Prism Royal Bow",
            WikiLink = "http://pathofexile.gamepedia.com/Doomfletch's Prism",
            Buyout = DesignPrice,
            SellerId = "Test Seller Account 1",
            SellerAccountName = "Test Seller Account 1",
            SellerCharacterName = "Test Seller Character 10",
            StashX = 0,
            StashY = 0,
            Quality = "20",
            RequiredLevel = "Level: 40",
            ItemLevel = "ilvl: 70",
            MaxSockets = "Max sockets: 6 (6)",
            SocketLinks = new List<SocketLink> {
                new SocketLink {
                    Red = 1,
                    Green = 4
                },
                new SocketLink {
                    Green = 1
                }
            },
            Modifiers = new List<Modifier> {
                new Modifier {
                    Value = "Adds 15.5 to 15.5 Physical Damage"
                },
                new Modifier {
                    Value = "12.0% increased Attack Speed"
                },
                new Modifier {
                    Value = "34.0% increased Critical Strike Chance"
                },
                new Modifier {
                    Value = "60.0% increased Mana Regeneration Rate"
                },
                new Modifier {
                    Value = "Gain 110% of Bow Physical Damage as Extra Damage of each Element"
                }
            }
        };
    }
}
