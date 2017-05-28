using System.IO;
using System.Net.Sockets;
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
                var result = await _udpClient.ReceiveAsync();

                Configuration.Current.ItemConfiguration.CurrentItemSearches.Add(
                    JsonSerializerExtension.Serializer.DeserializeFromStream<ItemSearch>(
                        new MemoryStream(result.Buffer)));
            }
        }
    }
}
