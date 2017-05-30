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
    }
}
