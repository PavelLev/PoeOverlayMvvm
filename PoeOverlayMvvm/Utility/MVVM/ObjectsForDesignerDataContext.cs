using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.Item;

namespace PoeOverlayMvvm.Utility.MVVM {
    public static class ObjectsForDesignerDataContext {
        public static SearchItem TestObserver1 { get; } = new SearchItem("Test ItemObserver", "Test Url", "Test WebSocketUrl", new Price{Quantity = -1,Currency = Currency.ByName("chaos")}, false);
    }
}
