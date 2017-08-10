using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.SearchEngine;
using PoeOverlayMvvm.UserControls;

namespace PoeOverlayMvvm {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        private void App_OnStartup(object sender, StartupEventArgs e) {
            switch (e.Args.Length) {
                case 1:
                    var bytes = Encoding.UTF8.GetBytes(e.Args[0]);
                    new UdpClient().Send(bytes, bytes.Length, "127.0.0.1", ItemSearchUdpServer.Port);
                    Shutdown();
                    break;
                default:
                    TrySetProtocol();
                    Configuration.Load();
                    
                    
                    ;
                    ItemSearchInteraction.Initialize();
                    AllCurrenciesObserver.Load();
                    ItemSearchUdpServer.Load();


                    MainWindow = new MainWindow();
                    MainWindow.Show();
                    break;
            }
        }

        public new static App Current => (App) Application.Current;

        public new void Shutdown() {
            Configuration.Save();
            base.Shutdown();
        }

        void TrySetProtocol()
        {
            var registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Classes\poeoverlay");
            registryKey.SetValue("", "URL:poeoverlay protocol");
            registryKey.SetValue("URL Protocol", "");
            registryKey = registryKey.CreateSubKey(@"shell\\open\\command");
            registryKey.SetValue("", Assembly.GetEntryAssembly().Location + @" ""%1""");
        }
    }
}
