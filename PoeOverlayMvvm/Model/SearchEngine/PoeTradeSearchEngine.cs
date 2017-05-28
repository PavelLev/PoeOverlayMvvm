using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Utility;
using WebSocketSharp;

namespace PoeOverlayMvvm.Model.SearchEngine
{
    [JsonObject]
    public class PoeTradeSearchEngine : ISearchEngine
    {
        [JsonProperty]
        public string Id { get; set; }

        public event Action<Item> OfferedItemFound;

        [JsonProperty]
        public string PostUrl { get; set; }
        [JsonProperty]
        public string WebSocketUrl { get; set; }
        private int PostId { get; set; } = -1;
        private WebSocket WebSocketInstance { get; set; }
        
        public void Initialize() {
            WebSocketInstance = new WebSocket(WebSocketUrl);
            WebSocketInstance.OnMessage += async (sender, messageEventArgs) => {
                var postResponse = await Post();

                foreach (var offeredItem in await OfferedItemsHtmlParser.Parse(postResponse.Data)) {
                    OfferedItemFound?.Invoke(offeredItem);
                }
            };

            Post().ContinueWith(task => {
                PostId = task.Result.NewId;
            });
        }

        public void Start() {
            WebSocketInstance.Connect();
        }

        public void Stop() {
            WebSocketInstance.Close();
            PostId = -1;
        }

        private async Task<PostResponse> Post() {
            return JsonSerializerExtension.Serializer.DeserializeFromStream<PostResponse>(await (await MyHttpClient.PostAsync(
                PostUrl, new FormUrlEncodedContent(
                    new Dictionary<string, string> {
                        {"id", PostId.ToString()}
                    }))).Content.ReadAsStreamAsync());
        }
    }
}
