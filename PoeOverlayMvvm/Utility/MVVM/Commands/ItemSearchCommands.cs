using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM.Commands {
    public static class ItemSearchCommands {
        private static RelayCommand _moveToCurrent;
        private static RelayCommand _moveToOld;

        public static RelayCommand MoveToCurrent => _moveToCurrent ?? (_moveToCurrent = new RelayCommand(parameter => {
            if (Configuration.Current.ItemConfiguration.OldItemSearches.Remove((ItemSearch)parameter)) {
                Configuration.Current.ItemConfiguration.CurrentItemSearches.Insert(0, (ItemSearch)parameter);
                ((ItemSearch)parameter).SearchEngine.Start();
            }
        }));

        public static RelayCommand MoveToOld => _moveToOld ?? (_moveToOld = new RelayCommand(parameter => {
            if (Configuration.Current.ItemConfiguration.CurrentItemSearches.Remove((ItemSearch)parameter)) {
                Configuration.Current.ItemConfiguration.OldItemSearches.Insert(0, (ItemSearch)parameter);
                ((ItemSearch)parameter).SearchEngine.Stop();
            }
        }));
    }
}
