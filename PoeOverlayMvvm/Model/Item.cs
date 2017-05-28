using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model.ItemData;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Model
{
    [JsonObject]
    public class Item {
        private string _whisper;
        private Price _buyout;

        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string WikiLink { get; set; }

        [JsonProperty]
        public Price Buyout {
            get => _buyout;
            set {
                _buyout = value;
                GenerateWhisper();
            }
        }

        [JsonProperty]
        public string SellerId { get; set; }
        [JsonProperty]
        public string SellerAccountName { get; set; }
        [JsonProperty]
        public string SellerCharacterName { get; set; }
        [JsonProperty]
        public string StashTab { get; set; }
        [JsonProperty]
        public int StashX { get; set; }
        [JsonProperty]
        public int StashY { get; set; }

        [JsonProperty]
        public string GemLevel { get; set; }
        [JsonProperty]
        public string Quality { get; set; }
        [JsonProperty]
        public string RequiredLevel { get; set; }
        [JsonProperty]
        public string ItemLevel { get; set; }
        [JsonProperty]
        public string MaxSockets { get; set; }
        [JsonProperty]
        public List<SocketLink> SocketLinks { get; set; }
        [JsonProperty]
        public List<Modifier> Modifiers { get; set; }

        public string Whisper {
            get {
                if (_whisper == null) {
                    GenerateWhisper();
                }
                return _whisper;
            }
        }

        public void SendWhisper() {
            PoeInteractionAutomation.SendChatMessage(Whisper);
        }

        private void GenerateWhisper() {
            // function from poe.trade for creating whisper message
            //function whisperMessage(o)
            //{
            //    var item = $(o).parents(".item");
            //    var bo = item.data("buyout") ? " listed for " + item.data("buyout") : "";
            //    var prefix = "";
            //    if (item.data("level") != undefined)
            //        prefix += "level " + item.data("level") + " ";
            //    if (item.data("quality") != undefined)
            //        prefix += item.data("quality") + "% ";
            //    var message = "@" + item.data("ign") + " Hi, I would like to buy your " + prefix + item.data("name") + bo + " in " + item.data("league");
            //    var tab = item.data("tab");
            //    if (tab)
            //    {
            //        var x = item.data("x")
            //            , y = item.data("y");
            //        message += ' (stash tab "' + tab + '"';
            //        if (x >= 0 && y >= 0)
            //            message += "; position: left " + (x + 1) + ", top " + (y + 1);
            //        message += ')';
            //    }
            //    return message;
            //}
            var whisperBuilder = new StringBuilder("@")
                .Append(SellerCharacterName)
                .Append(" Hi, I would like to buy your ");

            //Maybe wrong and need to split data("quality")
            if (GemLevel != null) {
                whisperBuilder.Append("level ")
                    .Append(GemLevel)
                    .Append(" ")
                    .Append(Quality)
                    .Append("% ");
            }

            whisperBuilder.Append(Name);

            if (Buyout != null) {
                whisperBuilder.Append(" listed for ")
                    .Append(Buyout.Quantity)
                    .Append(" ")
                    .Append(Buyout.CurrencyShortName);
            }

            whisperBuilder.Append(" in ")
                .Append(Configuration.Current.LeagueName);

            if (StashTab != null) {
                whisperBuilder.Append(" (stash tab \"")
                    .Append(StashTab)
                    .Append("\"");
                if (StashX > 0 && StashY > 0) {
                    whisperBuilder.Append("; position: left ")
                        .Append(StashX)
                        .Append(", top ")
                        .Append(StashY);
                }
                whisperBuilder.Append(")");
            }

            _whisper = whisperBuilder.ToString();
        }
    }
}
