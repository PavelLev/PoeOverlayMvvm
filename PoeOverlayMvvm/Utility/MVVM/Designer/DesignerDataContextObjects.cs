using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Model.SearchEngine;

namespace PoeOverlayMvvm.Utility.MVVM.Designer {
    public static class DesignerDataContextObjects {
        public static Price DesignPrice { get; } =
            new Price {CurrencyShortName = "chaos", Quantity = -12};

        public static ItemSearch DesignItemSearch { get; } =
            new ItemSearch("Test ItemObserver", new DesignerSearchEngine(), DesignPrice, true);

        public static ApplicationViewModel DesignViewModel { get; } =
            new ApplicationViewModel {ItemSearchesHistoryIsVisible = false};
    }
}
