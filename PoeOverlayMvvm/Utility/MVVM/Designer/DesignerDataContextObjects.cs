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
                OldItemSearchesFilter = "12",
            };
        public static ItemsPanel DesignItemsPanel { get; } =
            new ItemsPanel {
                ItemsHistoryIsVisible = true,
                CurrentItemsFilter = "",
                OldItemsFilter = "",
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
            GemLevel = "Gem level: 19",
            Quality = "Quality: 18",
            RequiredLevel = "Level: 64",
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
            Quality = "Quality: 20",
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
                },
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
                },
            },
        };

        public static Item BroodClaspCrystalBelt { get; } = new Item {
            Id = "wer23zsdye4rtgr5uy67978ijh",
            Name = "Brood Clasp Crystal Belt",
            Buyout = DesignPrice,
            SellerId = "Test Seller Account 2",
            SellerAccountName = "Test Seller Account 2",
            SellerCharacterName = "Test Seller Character 2",
            StashX = 0,
            StashY = 0,
            RequiredLevel = "Level: 79",
            ItemLevel = "ilvl: 80",
            Modifiers = new List<Modifier> {
                new Modifier {
                    Value = "+80 to maximum Energy Shield"
                },
                new Modifier {
                    Value = "+184 to Armour",
                    ShortTier = "P3",
                    FullTier = "Tier 3 prefix: Plated, min=[139] max=[322]"
                },
                new Modifier {
                    Value = "1.4 Life Regenerated per second",
                    ShortTier = "S6",
                    FullTier = "Tier 6 suffix: of the Newt, min=[1] max=[2]"
                },
                new Modifier {
                    Value = "+29 to maximum Energy Shield",
                    ShortTier = "P5",
                    FullTier = "Tier 5 prefix: Blazing, min=[27] max=[31]"
                },
                new Modifier {
                    Value = "+44% to Fire Resistance",
                    ShortTier = "S2",
                    FullTier = "Tier 2 suffix: of the Magma, min=[42] max=[45]"
                },
                new Modifier {
                    Value = "+25% to Cold Resistance",
                    ShortTier = "S5",
                    FullTier = "Tier 5 suffix: of the Yeti, min=[24] max=[29]"
                },
                new Modifier {
                    Value = "crafted 8% increased Flask Mana Recovery rate",
                },
            },
        };

        public static Item BloodStrapCrystalBelt { get; } = new Item {
            Id = "uifhs78348sgjeirog09ik90io",
            Name = "Blood Strap Crystal Belt",
            Buyout = DesignPrice,
            SellerId = "Test Seller Account 3",
            SellerAccountName = "Test Seller Account 3",
            SellerCharacterName = "Test Seller Character 3",
            StashX = 0,
            StashY = 0,
            RequiredLevel = "Level: 79",
            ItemLevel = "ilvl: 80",
            Modifiers = new List<Modifier> {
                new Modifier {
                    Value = "+71 to maximum Energy Shield"
                },
                new Modifier {
                    Value = "+172 to Armour",
                    ShortTier = "P3",
                    FullTier = "Tier 3 prefix: Plated, min=[139] max=[322]"
                },
                new Modifier {
                    Value = "+61 to maximum Life",
                    ShortTier = "P4",
                    FullTier = "Tier 4 prefix: Rotund, min=[60] max=[69]"
                },
                new Modifier {
                    Value = "+36 to maximum Energy Shield",
                    ShortTier = "P4",
                    FullTier = "Tier 4 prefix: Scintillating, min=[32] max=[37]"
                },
                new Modifier {
                    Value = "+44% to Cold Resistance",
                    ShortTier = "S2",
                    FullTier = "Tier 2 suffix: of the Ice, min=[42] max=[45]"
                },
                new Modifier {
                    Value = "+32% to Lightning Resistance",
                    ShortTier = "S4",
                    FullTier = "Tier 4 suffix: of the Tempest, min=[30] max=[35]"
                },
                new Modifier {
                    Value = "crafted +25% to Fire Resistance",
                },
            },
        };
    }
}
