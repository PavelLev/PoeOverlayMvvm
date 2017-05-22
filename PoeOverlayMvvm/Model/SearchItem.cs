using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.Item;
using PoeOverlayMvvm.Utility;
using PoeOverlayMvvm.Utility.MVVM;
using WebSocketSharp;

namespace PoeOverlayMvvm.Model {
    [JsonObject]
    public class SearchItem: MyObservable {
        private string _name;
        private bool _autoWhisper;

        [JsonProperty]
        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }

        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public string WebSocketUrl { get; set; }

        [JsonProperty]
        public Price DesiredPrice { get; set; }

        [JsonProperty]
        public bool AutoWhisper {
            get => _autoWhisper;
            set => SetField(ref _autoWhisper, value);
        }

        public WebSocket WebSocketInstance { get; set; }

        private int PostId { get; set; } = -1;

        [JsonConstructor]
        public SearchItem(string name, string url, string webSocketUrl, Price desiredPrice, bool autoWhisper) {
            Name = name;
            Url = url;
            WebSocketUrl = webSocketUrl;
            DesiredPrice = desiredPrice;
            AutoWhisper = autoWhisper;

            WebSocketInstance = new WebSocket(WebSocketUrl);
            WebSocketInstance.OnMessage += WebSocketOnMessage;

            Post().ContinueWith(task => {
                PostId = task.Result.NewId;
            });
        }

        public void ActivateWebSockets() {
            WebSocketInstance.ConnectAsync();
        }

        private async void WebSocketOnMessage(object sender, MessageEventArgs messageEventArgs) {
            if (!messageEventArgs.Data.StartsWith("{\"type\":\"del\",\"value\":\"")) {
                //Websocket has informed that new offers had appeared
                var postResponse = await Post();

                foreach (var offeredItem in await OfferedItemsHtmlParser.Parse(postResponse.Data)) {
                    Configuration.Current.ItemConfiguration.CurrentOfferedItems.Add(offeredItem);
                    if (AutoWhisper) {
                        offeredItem.SendWhisper();
                    }
                }
            }
            else {
                //Websocket has informed that seller removed his offer
                var deletedItemId = messageEventArgs.Data.Substring(23, messageEventArgs.Data.Length - 25);

                var currentOfferedItems = Configuration.Current.ItemConfiguration.CurrentOfferedItems;
                for (var i = 0; i < currentOfferedItems.Count; i++) {
                    var offeredItem = currentOfferedItems[i];
                    if (currentOfferedItems[i].Id != deletedItemId) {
                        continue;
                    }

                    currentOfferedItems.RemoveAt(i);
                    Configuration.Current.ItemConfiguration.OldOfferedItems.Add(offeredItem);
                    break;
                }
            }
        }

        private async Task<PostResponse> Post() {
            return JsonSerializerExtension.Serializer.DeserializeFromStream<PostResponse>(await(await MyHttpClient.PostAsync(
                Url, new FormUrlEncodedContent(
                    new Dictionary<string, string> {
                        {"id", PostId.ToString()}
                    }))).Content.ReadAsStreamAsync());
        }
    }
}
