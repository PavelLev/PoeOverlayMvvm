using System;

namespace PoeOverlayMvvm.Model
{
    public interface ISearchEngine {
        // by default search engine is initialized and stopped
        event Action<Item> OfferedItemFound;
        string Id { get; set; }
        void Initialize();
        void Start();
        void Stop();
    }
}
