using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PoeOverlayMvvm.Logic;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Model {
    public sealed class CurrencyTradeOffer {
        public static Regex OfferRegex { get; } = new Regex("<div class=\"displayoffer-middle\">(\\d+) &lArr; (\\d+)</div>");
        public Currency OfferedCurrency { get; set; }
        public double OfferedQuantity { get; set; }
        public Currency RequestedCurrency { get; set; }
        public double RequestedQuantity { get; set; }
        public double ForOneRequested => RequestedQuantity / OfferedQuantity;
        public double ForOneOffered => OfferedQuantity / RequestedQuantity;


        public CurrencyTradeOffer(Currency offeredCurrency, double offeredQuantity, Currency requestedCurrency, double requestedQuantity) {
            OfferedCurrency = offeredCurrency;
            OfferedQuantity = offeredQuantity;
            RequestedCurrency = requestedCurrency;
            RequestedQuantity = requestedQuantity;
        }

        public static Task<IEnumerable<CurrencyTradeOffer>> GetTradeOffers(Currency offeredCurrency, Currency requestedCurrency) {
            return GetTradeOffersRegex(offeredCurrency, requestedCurrency);
        }

        private static async Task<IEnumerable<CurrencyTradeOffer>> GetTradeOffersRegex(Currency offeredCurrency, Currency requestedCurrency) {
            var url = $"{Configuration.Current.CurrencyConfiguration.CurrencyDomain}/search?league={Configuration.Current.LeagueName}&online=x&want={offeredCurrency.Id}&have={requestedCurrency.Id}";
            var pageString = await MyHttpClient.GetStringAsync(url);

            return OfferRegex.Matches(pageString)
                .Cast<Match>()
                .Select(match => new CurrencyTradeOffer(offeredCurrency, int.Parse(match.Groups[1].Value), requestedCurrency,
                    int.Parse(match.Groups[2].Value))).ToList();
        }

        private static async Task<IEnumerable<CurrencyTradeOffer>> GetTradeOffersMix(Currency offeredCurrency,
            Currency requestedCurrency) {
            var url = $"{Configuration.Current.CurrencyConfiguration.CurrencyDomain}/search?league={Configuration.Current.LeagueName}&online=x&want={offeredCurrency.Id}&have={requestedCurrency.Id}";
            var pageString = await MyHttpClient.GetStringAsync(url);

            var document = new HtmlDocument();
            document.LoadHtml(pageString);

            return document.DocumentNode
                .Descendants("div")
                .Where(node => node.Attributes.Contains("class") &&
                               node.Attributes["class"].Value == "displayoffer-middle")
                .Select(node => {
                    var index = node.InnerText.IndexOf(" ");
                    return new CurrencyTradeOffer(offeredCurrency,
                        double.Parse(node.InnerText.Substring(0, index - 1)),
                        requestedCurrency,
                        double.Parse(node.InnerText.Substring(index + 3)));
                });

        }
    }
}
