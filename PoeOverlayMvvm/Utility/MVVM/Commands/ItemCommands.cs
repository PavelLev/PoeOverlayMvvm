using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.MVVM.Commands
{
    public static class ItemCommands
    {
        private static RelayCommand _moveToCurrent;
        private static RelayCommand _moveToOld;
        private static RelayCommand _whisper;

        public static RelayCommand MoveToCurrent => _moveToCurrent ?? (_moveToCurrent = new RelayCommand(parameter => {
            if (Configuration.Current.ItemConfiguration.OldItems.Remove((Item)parameter))
            {
                Configuration.Current.ItemConfiguration.CurrentItems.Insert(0, (Item)parameter);
            }
        }));

        public static RelayCommand MoveToOld => _moveToOld ?? (_moveToOld = new RelayCommand(parameter => {
            if (Configuration.Current.ItemConfiguration.CurrentItems.Remove((Item)parameter))
            {
                Configuration.Current.ItemConfiguration.OldItems.Insert(0, (Item)parameter);
            }
        }));

        public static RelayCommand Whisper => _whisper ?? (_whisper = new RelayCommand(parameter => {
            ((Item)parameter).SendWhisper();
        }));
    }
}
