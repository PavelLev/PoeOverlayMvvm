using System.IO;
using System.Net.Sockets;
using System.Text;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Logic
{
    public static class ItemSearchUdpServer {
        public static int Port => 8013;
        private static UdpClient _udpClient;

        public static async void Load() {
            if (_udpClient != null) {
                return;
            }
            _udpClient = new UdpClient(Port);

            while (true) {
                // "poeoverlay:{...}
                var url = Encoding.UTF8.GetString((await _udpClient.ReceiveAsync()).Buffer);
                var result = url.Substring(url.IndexOf(':') + 1);

                // " replaced to @
                result = result.Replace("@", "\"");

                var itemSearch = JsonSerializerExtension.Serializer.DeserializeFromString<ItemSearch>(
                    result);
                
                Configuration.Current.ItemConfiguration.CurrentItemSearches.Add(itemSearch);

                itemSearch.SearchEngine.Start();
            }
        }
    }
}
