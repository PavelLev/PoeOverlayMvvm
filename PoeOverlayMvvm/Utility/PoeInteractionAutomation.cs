using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoeOverlayMvvm.Utility
{
    public static class PoeInteractionAutomation
    {
        public static void SendChatMessage(string message) {
            Clipboard.SetText(message);

            //open chat
            SendKeys.SendWait("{ENTER}");

            //paste message
            SendKeys.SendWait("^v");

            //close chat
            SendKeys.SendWait("{ENTER}");

        }
    }
}
