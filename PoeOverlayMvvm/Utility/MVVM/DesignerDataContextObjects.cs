using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Model.SearchEngine;

namespace PoeOverlayMvvm.Utility.MVVM {
    public static class DesignerDataContextObjects {
        public static Price DesignPrice { get; } =
            new Price { Currency = new Currency { LongName = "Test Orb" }, Quantity = -12 };
        public static ItemSearch DesignItemSearch { get; } = new ItemSearch("Test ItemObserver", new PoeTradeSearchEngine(), DesignPrice, true);

    }
}
