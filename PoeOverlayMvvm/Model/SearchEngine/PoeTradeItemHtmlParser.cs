using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using PoeOverlayMvvm.Model.ItemData;

namespace PoeOverlayMvvm.Model.SearchEngine
{
    public static class OfferedItemsHtmlParser
    {
        public static async Task<List<Item>> Parse(string data) {
            var document = await new HtmlParser().ParseAsync(data);

            return document.QuerySelectorAll(".item")
                .Select(node => {
                    var offeredItem = new Item();

                    offeredItem.Id = node.ClassList[1].Substring(10); // 10 - length of prefix "item-live-"

                    var nameBuilder = new StringBuilder();
                    if (node.QuerySelector("span.label.success.corrupted") != null) {
                        nameBuilder.Append("corrupted ");
                    }
                    offeredItem.Name = nameBuilder.Append(node.Attributes["data-name"].Value)
                        .ToString();

                    offeredItem.WikiLink = node.QuerySelector("a.wiki-link")?.Attributes["href"]?.Value;

                    if (node.Attributes["data-buyout"].Value != "") {
                        offeredItem.Buyout = ParsePrice(node.Attributes["data-buyout"].Value);
                    }

                    offeredItem.SellerId = node.Attributes["data-sellerid"].Value;
                    offeredItem.SellerAccountName = node.Attributes["data-seller"].Value;
                    offeredItem.SellerCharacterName = node.Attributes["data-ign"].Value;
                    offeredItem.StashTab = node.Attributes["data-tab"]?.Value;
                    offeredItem.StashX = int.Parse(node.Attributes["data-x"].Value) + 1;
                    offeredItem.StashY = int.Parse(node.Attributes["data-y"].Value) + 1;

                    offeredItem.GemLevel = node.Attributes["data-level"]?.Value;
                    offeredItem.Quality =
                        node.Attributes["data-quality"]?.Value ?? node.QuerySelector("td[data-name='q']")
                            .TextContent;
                    if (offeredItem.Quality[0] == 160) {
                        offeredItem.Quality = null;
                    }

                    offeredItem.RequiredLevel =
                        node.QuerySelector("ul.requirements.proplist").Children[0]?.TextContent ?? "Level: 1";
                    offeredItem.ItemLevel = node.QuerySelector("span.sortable[data-name='ilvl']")?.TextContent;

                    offeredItem.MaxSockets = node.QuerySelector("span[class='has-tip ']")?.TextContent;
                    offeredItem.Modifiers = node.QuerySelector(".bullet-item")
                        ?.QuerySelectorAll("li")
                        ?.Select(modifierNode => {
                            var modifier = new Modifier();

                            var valueBuilder = new StringBuilder();

                            var modifierSourceNode = modifierNode.Children.FirstOrDefault();
                            if (modifierSourceNode?.TagName?.Equals("SPAN") ?? false) {
                                valueBuilder.Append(modifierSourceNode.TextContent)
                                    .Append(" ");
                            }

                            var unmodifiedValue = modifierNode.Attributes["data-name"].Value;
                            modifier.Value = valueBuilder.Append(unmodifiedValue, 1, unmodifiedValue.Length - 1)
                                .Replace("#", modifierNode.Attributes["data-value"]?.Value)
                                .ToString();

                            var modifierTierNode = modifierNode.Children.LastOrDefault();
                            if (modifierTierNode?.TagName?.Equals("SPAN") ?? false) {
                                modifier.ShortTier = modifierTierNode.Children[0].TextContent;
                                modifier.FullTier = modifierTierNode.Children[1].TextContent;
                            }

                            return modifier;
                        })
                        .ToList();
                    

                    var socketLinksText = node.QuerySelector("span.sockets-raw").TextContent;
                    if (socketLinksText != "") {
                        offeredItem.SocketLinks = socketLinksText.Split(new[] { ' ' })
                            .Select(socketLinkText => {
                                var socketLink = new SocketLink();

                                foreach (var socketText in socketLinkText.Split(new[] { '-' })) {
                                    socketLink.AddSocketByText(socketText);
                                }

                                return socketLink;
                            })
                            .ToList();
                    }

                    return offeredItem;
                })
                .ToList();
        }

        private static void AddSocketByText(this SocketLink socketLink, string color) {
            switch (color) {
                case "R":
                    socketLink.Red++;
                    break;
                case "G":
                    socketLink.Green++;
                    break;
                case "B":
                    socketLink.Blue++;
                    break;
                case "W":
                    socketLink.White++;
                    break;
            }
        }

        private static Price ParsePrice(string value) {
            var parts = value.Split(' ');
            return new Price {
                Quantity = double.Parse(parts[0]),
                CurrencyShortName = parts[1]
            };
        }
    }
}
