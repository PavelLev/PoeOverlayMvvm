using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;
using static PoeOverlayMvvm.Utility.WinApi;

namespace PoeOverlayMvvm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private WinEventDelegate _windowsEventMethod;
        private Timer _timer;
        

        private readonly List<string> _targetTitles = Configuration.Current.TargetTitles;

        public static List<int> TestTimeList = new List<int>();

        private readonly Dictionary<object, Timer> _textBoxDelayTimers = new Dictionary<object, Timer>();

        public MainWindow() {
            InitializeComponent();

            _targetTitles.Add(Title);

            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.TextChangedEvent, new RoutedEventHandler(
                (sender, routedEventArgs) => {
                    if (!((TextBox) sender).Name.EndsWith("DelayedTextBox")) {
                        return;
                    }

                    if (!_textBoxDelayTimers.ContainsKey(sender)) {
                        _textBoxDelayTimers[sender] = new Timer(state => {
                            Dispatcher.Invoke(((TextBox) state).GetBindingExpression(TextBox.TextProperty)
                                .UpdateSource);
                        }, sender, Timeout.Infinite, Timeout.Infinite);
                    }

                    _textBoxDelayTimers[sender].Change(Configuration.Current.TextBoxDelay, Timeout.Infinite);
                }));
            
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.KeyUpEvent, new KeyEventHandler(
                (sender, keyEventArgs) => {
                    if (keyEventArgs.Key == Key.Enter) {
                        Dispatcher.Invoke(((TextBox)sender).GetBindingExpression(TextBox.TextProperty)
                            .UpdateSource);
                    }
                }));

        }

        public async void WindowsEventMethod(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime) {
            await Task.Delay(200);

            var windowHandle = GetForegroundWindow();
            var title = GetWindowTitle(windowHandle);

            if (title == null) {
                return;
            }

            if (title == "Path of Exile" && GameWindowHandle == IntPtr.Zero) {
                GameWindowHandle = windowHandle;
            }


            ((ApplicationViewModel)App.Current.Resources["ApplicationViewModel"]).IsForeground = _targetTitles.Any(targetTitle => title.StartsWith(targetTitle));
            
            //Visibility = _targetTitles.Any(targetTitle => title.StartsWith(targetTitle))
            //    ? Visibility.Visible
            //    : Visibility.Visible;
        }

        private void Window_StateChanged(object sender, EventArgs e) {
            _timer = new Timer(state => {
                Dispatcher.Invoke(() => {
                    WindowState = WindowState.Normal;
                });
                _timer = null;
            }, null, 50, 0);
        }

        private void MainWindow_OnSourceInitialized(object sender, EventArgs e) {
            var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource == null) {
                MessageBox.Show("Can't hook wndproc to handle hotkeys");
                Application.Current.Shutdown();
                return;
            }
            hwndSource.AddHook(WndProc);

            foreach (var hotKey in HotKeyHandler.HotKeys) {
                var result = RegisterHotKey(Handle, hotKey.Id, hotKey.KeyModifier, hotKey.Key);
                if (result) {
                    continue;
                }
                MessageBox.Show("Can't register \"" + hotKey.Name + "\" hotkey with error " + Marshal.GetLastWin32Error());
                Application.Current.Shutdown();
                return;
            }

            _windowsEventMethod = new WinEventDelegate(WindowsEventMethod);
            var result2 = SetWinEventHook(EventConstant.EventSystemForeground, EventConstant.EventSystemForeground, IntPtr.Zero, _windowsEventMethod, 0, 0, WineventFlag.WineventOutofcontext);
            if (result2 == IntPtr.Zero) {
                MessageBox.Show("Can't set winevent hook to track current foreground window");
                Application.Current.Shutdown();
                return;
            }

            //Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            foreach (var hotKey in HotKeyHandler.HotKeys) {
                UnregisterHotKey(Handle, hotKey.Id);
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            switch (msg) {
                case WmHotkey:
                    // wParam - hot key id
                    // lParam - high order - virtual key identifier of pressed key, low order - keymodifier
                    HotKeyHandler.HotKeys.First(hotKey => hotKey.Id == (int) wParam).Action();
                    handled = true;
                    break;
                default:
                    handled = false;
                    break;
            }

            return IntPtr.Zero;
        }

        private IntPtr Handle => new WindowInteropHelper(this).Handle;
        

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            (sender as Button).Content = TestTimeList.Count == 0 ? 0 : TestTimeList.Skip(TestTimeList.Count - 10).Average();
        }
    }
}
