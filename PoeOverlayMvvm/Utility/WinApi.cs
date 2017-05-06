using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PoeOverlayMvvm.Utility {
    public static class WinApi {

        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetLastError();

        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(EventConstant eventMin, EventConstant eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, WineventFlag dwFlags);

        public enum EventConstant {
            EventSystemForeground = 3
        }

        public enum WineventFlag {
            WineventOutofcontext = 0
        }

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr windowHandle, StringBuilder text, int count);
        
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// wrapper for GetWindowText, that returns string
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <returns></returns>
        public static string GetWindowTitle(IntPtr windowHandle) {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            
            return GetWindowText(windowHandle, buff, nChars) > 0 ? buff.ToString() : null;
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr windowHandle, int hotKeyId, KeyModifier keyModifiers, int virtualKey);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr windowHandle, int hotKeyId);

        public enum KeyModifier {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8,
            NoRepeat = 0x4000
        }
        
        public const int WmHotkey = 0x0312;
    }
}
