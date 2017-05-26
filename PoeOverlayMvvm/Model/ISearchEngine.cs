using System;

namespace PoeOverlayMvvm.Model
{
    public interface ISearchEngine {
        event Action<Item> OfferedItemFound;
        string Id { get; set; }
        void Search();
    }
}
