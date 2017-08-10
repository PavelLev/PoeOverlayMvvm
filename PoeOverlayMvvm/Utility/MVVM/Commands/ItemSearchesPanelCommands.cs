using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM.Commands
{
    public static class ItemSearchesPanelCommands
    {
        private static RelayCommand _clearHistory;

        public static RelayCommand ClearHistory => _clearHistory ?? (_clearHistory = new RelayCommand(parameter => {
            Configuration.Current.ItemConfiguration.OldItemSearches.Clear();
        }));
    }
}
