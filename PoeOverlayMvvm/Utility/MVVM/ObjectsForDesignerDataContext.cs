using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM {
    public static class ObjectsForDesignerDataContext {
        public static Observer TestObserver1 { get; } = new Observer("Test Observer", "Test Url", -1, Currency.ByName("chaos"), false);
    }
}
