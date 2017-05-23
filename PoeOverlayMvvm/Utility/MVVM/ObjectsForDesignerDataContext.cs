using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM {
    public static class ObjectsForDesignerDataContext {
        public static ItemSearch TestObserver1 { get; } = new ItemSearch("Test ItemObserver", "Test Url", "Test WebSocketUrl", -1, Currency.ByName("chaos"), false);
    }
}
