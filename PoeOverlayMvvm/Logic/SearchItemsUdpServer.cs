using System.IO;
using System.Net.Sockets;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Logic
{
    public static class SearchItemsUdpServer {
        public static int Port => 8013;
        private static UdpClient _udpClient;
        private static bool _isReceiving;

        public static async void Start() {
            if (_udpClient != null) {
                return;
            }
            _udpClient = new UdpClient(Port);

            while (true) {
                var result = await _udpClient.ReceiveAsync();

                Configuration.Current.ItemConfiguration.CurrentSearchItems.Add(
                    JsonSerializerExtension.Serializer.DeserializeFromStream<SearchItem>(
                        new MemoryStream(result.Buffer)));
            }
        }
    }
}
