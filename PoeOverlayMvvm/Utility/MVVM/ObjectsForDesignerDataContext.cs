﻿using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM {
    public static class ObjectsForDesignerDataContext {
        public static SearchItem TestObserver1 { get; } = new SearchItem("Test ItemObserver", "Test Url", "Test WebSocketUrl", -1, Currency.ByName("chaos"), false);
    }
}
