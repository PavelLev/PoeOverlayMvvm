using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Extensions;
using AngleSharp.Parser.Html;
using PoeOverlayMvvm.Model.ItemData;

namespace PoeOverlayMvvm.Model.SearchEngine
{
    public static class PoeTradeItemHtmlParser
    {
        public static async Task<List<Item>> Parse(string data) {
            var document = await new HtmlParser().ParseAsync(data);

            return document.QuerySelectorAll(".item")
                .Select(node => {
                    var item = new Item();

                    item.Id = node.ClassList[1].Substring(10); // 10 - length of prefix "item-live-"

                    var nameBuilder = new StringBuilder();
                    if (node.QuerySelector("span.label.success.corrupted") != null) {
                        nameBuilder.Append("corrupted ");
                    }
                    item.Name = nameBuilder.Append(node.Attributes["data-name"].Value)
                        .ToString();

                    item.WikiLink = node.QuerySelector("a.wiki-link")?.Attributes["href"]?.Value;

                    item.Buyout = node.Attributes["data-buyout"].Value != "" ? ParsePrice(node.Attributes["data-buyout"].Value) : Price.Empty;

                    item.SellerId = node.Attributes["data-sellerid"].Value;
                    item.SellerAccountName = node.Attributes["data-seller"].Value;
                    item.SellerCharacterName = node.Attributes["data-ign"].Value;
                    item.StashTab = node.Attributes["data-tab"]?.Value;
                    item.StashX = int.Parse(node.Attributes["data-x"].Value) + 1;
                    item.StashY = int.Parse(node.Attributes["data-y"].Value) + 1;

                    item.GemLevel = node.Attributes["data-level"]?.Value;
                    if (item.GemLevel != null) {
                        item.GemLevel = new StringBuilder("Gem level: ").Append(item.GemLevel).ToString();
                    }

                    item.Quality =
                        node.Attributes["data-quality"]?.Value ?? node.QuerySelector("td[data-name='q']")
                            .TextContent;
                    if (item.Quality[0] == 160) {
                        item.Quality = null;
                    }
                    if (item.Quality != null) {
                        item.Quality = new StringBuilder("Quality: ").Append(item.Quality).ToString();
                    }

                    var proplistChildren = node.QuerySelector("ul.requirements.proplist").Children;
                    item.RequiredLevel = proplistChildren.Length == 0
                        ? "Level: 1"
                        : proplistChildren[0]?.TextContent ?? "Level: 1";

                    item.ItemLevel = node.QuerySelector("span.sortable[data-name='ilvl']")?.TextContent;

                    item.MaxSockets = node.QuerySelector("span[class='has-tip ']")?.TextContent;
                    
                    item.Modifiers = ParseModifiers(node);


                    var socketLinksText = node.QuerySelector("span.sockets-raw").TextContent;
                    if (socketLinksText != "") {
                        item.SocketLinks = socketLinksText.Split(new[] {' '})
                            .Select(socketLinkText => {
                                var socketLink = new SocketLink();

                                foreach (var socketText in socketLinkText.Split(new[] {'-'})) {
                                    socketLink.AddSocketByText(socketText);
                                }

                                return socketLink;
                            })
                            .ToList();
                    }
                    else {
                        item.SocketLinks = new List<SocketLink>();
                    }

                    return item;
                })
                .ToList();
        }

        private static List<Modifier> ParseModifiers(IElement node)
        {
            //unidentified
            if (node.QuerySelector("ul.item-unid") != null) {
                return new List<Modifier> {
                    new Modifier {
                        Value = "Unidentified"
                    }
                };
            }

            return node.QuerySelector(".bullet-item")
                ?.QuerySelectorAll("li")
                ?.Select(modifierNode => {
                    var modifier = new Modifier();

                    var valueBuilder = new StringBuilder();

                    var modifierSourceNode = modifierNode.Children.FirstOrDefault();
                    if (modifierSourceNode?.TagName?.Equals("SPAN") ?? false)
                    {
                        valueBuilder.Append(modifierSourceNode.TextContent)
                            .Append(" ");
                    }

                    var unmodifiedValue = modifierNode.Attributes["data-name"].Value;
                    modifier.Value = valueBuilder.Append(unmodifiedValue, 1, unmodifiedValue.Length - 1)
                        .Replace("#", modifierNode.Attributes["data-value"]?.Value ?? "?")
                        .ToString();

                    modifier.ShortTier = modifierNode.QuerySelector("span.affix-info-short")?.TextContent;
                    modifier.FullTier = modifierNode.QuerySelector("span.affix-info-full")?.TextContent;

                    return modifier;
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
