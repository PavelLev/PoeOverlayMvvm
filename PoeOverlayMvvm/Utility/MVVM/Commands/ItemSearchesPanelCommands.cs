using System;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility.MVVM.CommandParameters;

namespace PoeOverlayMvvm.Utility.MVVM.Commands {
    public class ItemSearchesPanelCommands {
        private static RelayCommand _processSearch;

        public static RelayCommand ProcessSearch => _processSearch ??
                                                    (_processSearch = new RelayCommand(processSearchParameters => {
                                                        var itemsControl =
                                                            ((ProcessSearchParameters) processSearchParameters)
                                                            .ItemsControl;
                                                        var searchString = ((ProcessSearchParameters)processSearchParameters)
                                                            .SearchString;

                                                        foreach (var item in itemsControl.Items) {
                                                            
                                                        }
                                                    }));

        public static Func<object, string, bool> ItemSearchMatchesSearchString { get; } = (obj, searchString) => {
            var itemSearch = (ItemSearch) obj;
            return itemSearch.Name.Contains(searchString);
        };
    }
}
