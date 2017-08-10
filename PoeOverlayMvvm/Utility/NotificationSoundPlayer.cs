using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PoeOverlayMvvm.Utility
{
    public class NotificationSoundPlayer {
        private static SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.snd);

        public static void Play() {
            _soundPlayer.Play();    
        }
    }
}
