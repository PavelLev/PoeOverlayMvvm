using System.Net.Sockets;
using System.Text;
using System.Windows;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        private void App_OnStartup(object sender, StartupEventArgs e) {
            switch (e.Args.Length) {
                case 1:
                    var bytes = Encoding.UTF8.GetBytes(e.Args[0]);
                    new UdpClient().Send(bytes, bytes.Length, "127.0.0.1", SearchItemsUdpServer.Port);
                    Shutdown();
                    break;
                default:
                    Configuration.Load();
                    AllCurrenciesObserver.AutomaticUpdate();


                    MainWindow = new MainWindow();
                    MainWindow.Show();
                    break;
            }
        }
    }
}
