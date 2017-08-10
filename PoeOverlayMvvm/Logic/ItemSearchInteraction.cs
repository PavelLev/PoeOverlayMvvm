using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM.Designer;

namespace PoeOverlayMvvm.Logic
{
    public static class ItemSearchInteraction {
        public static ObservableCollection<Item> ItemsToWhisper { get; } = new ObservableCollection<Item>();
        public static void Initialize() {
            ItemSearch.ItemFound += (searchItem, item) => {
                App.Current.Dispatcher.Invoke(() => {
                    Configuration.Current.ItemConfiguration.CurrentItems.Add(item);
                    if (searchItem.AutoWhisper && !item.Buyout.IsEmpty()) {
                        NotificationSoundPlayer.Play();
                        ItemsToWhisper.Add(item);
                    }
                });
            };
        }
    }
}
