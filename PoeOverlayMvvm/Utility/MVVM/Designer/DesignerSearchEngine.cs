using System;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM.Designer {
    public class DesignerSearchEngine : ISearchEngine {
        public event Action<Item> OfferedItemFound;
        public string Id { get; set; }
        public void Initialize() {
        }

        public void Start() {
        }

        public void Stop() {
        }
    }
}
