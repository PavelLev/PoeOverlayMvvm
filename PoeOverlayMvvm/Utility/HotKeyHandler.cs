using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PoeOverlayMvvm.Logic;
using static PoeOverlayMvvm.Utility.WinApi;

namespace PoeOverlayMvvm.Utility
{
    public class HotKeyHandler {
        public static List<HotKey> HotKeys { get; } = new List<HotKey> {
            new HotKey("Hide",
                KeyModifier.Shift | KeyModifier.NoRepeat, 
                KeyInterop.VirtualKeyFromKey(Key.F2),
                () => {
                    ((ApplicationViewModel)App.Current.Resources["ApplicationViewModel"]).ToggleIsVisible();
                }),
            new HotKey("Close",
                KeyModifier.Alt | KeyModifier.NoRepeat,
                KeyInterop.VirtualKeyFromKey(Key.F2),
                () => {
                    if (!((ApplicationViewModel)App.Current.Resources["ApplicationViewModel"]).IsForeground) {
                        MessageBox.Show("PoeOverlay was closed");
                    }
                    App.Current.Shutdown();
                }),
            new HotKey("Whisper",
                KeyModifier.None,
                KeyInterop.VirtualKeyFromKey(Key.F2),
                () => {
                    if (ItemSearchInteraction.ItemsToWhisper.Count == 0) {
                        return;
                    }
                    ItemSearchInteraction.ItemsToWhisper[0].SendWhisper();
                    ItemSearchInteraction.ItemsToWhisper.RemoveAt(0);
                })
        };

        //public HotKey HideHotKey = new HotKey {
        //    Id = 0,
        //    KeyModifier = KeyModifier.Shift | KeyModifier.NoRepeat,
        //    Key = KeyInterop.VirtualKeyFromKey(Key.F2),
        //    Action = () => {
        //        //TODO
        //    }
        //};
        //public HotKey CloseHotKey = new HotKey
        //{
        //    Id = 1,
        //    KeyModifier = KeyModifier.Alt | KeyModifier.NoRepeat,
        //    Key = KeyInterop.VirtualKeyFromKey(Key.F2)
        //};
        //public HotKey SendWhisperHotKey = new HotKey
        //{
        //    Id = 2,
        //    KeyModifier = KeyModifier.None,
        //    Key = KeyInterop.VirtualKeyFromKey(Key.F2)
        //};
    }

    public class HotKey
    {
        private static int _uniqueId = 0;

        private static int GetUniqueId()
        {
            return _uniqueId++;
        }

        public string Name { get; }
        public int Id { get; }
        public KeyModifier KeyModifier { get; }
        public int Key { get; }
        public Action Action { get; }
        public HotKey(string name, KeyModifier keyModifier, int key, Action action)
        {
            Name = name;
            Id = GetUniqueId();
            KeyModifier = keyModifier;
            Key = key;
            Action = action;
        }
    }
}
