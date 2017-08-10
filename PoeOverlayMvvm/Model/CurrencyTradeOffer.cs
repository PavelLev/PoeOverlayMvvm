using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Model {
    public sealed class CurrencyTradeOffer {
        private static HtmlParser htmlParser = new HtmlParser();
        public static Regex OfferRegex { get; } = new Regex("<div class=\"displayoffer-middle\">(\\d+) &lArr; (\\d+)</div>");
        public Currency OfferedCurrency { get; set; }
        public double OfferedQuantity { get; set; }
        public Currency RequestedCurrency { get; set; }
        public double RequestedQuantity { get; set; }
        public double ForOneRequested => OfferedQuantity / RequestedQuantity;
        public double ForOneOffered => RequestedQuantity / OfferedQuantity;


        public CurrencyTradeOffer(Currency offeredCurrency, double offeredQuantity, Currency requestedCurrency, double requestedQuantity) {
            OfferedCurrency = offeredCurrency;
            OfferedQuantity = offeredQuantity;
            RequestedCurrency = requestedCurrency;
            RequestedQuantity = requestedQuantity;
        }

        public static Task<IEnumerable<CurrencyTradeOffer>> GetTradeOffers(Currency offeredCurrency, Currency requestedCurrency) {
            return GetTradeOffersAngleSharp(offeredCurrency, requestedCurrency);
        }

        private static async Task<IEnumerable<CurrencyTradeOffer>> GetTradeOffersAngleSharp(Currency offeredCurrency,
            Currency requestedCurrency)
        {
            var url = GeneratePoeTradeUrl(offeredCurrency.Id, requestedCurrency.Id);
            

            var document = await htmlParser.ParseAsync(await MyHttpClient.GetStreamAsync(url));

            return document.QuerySelector("#content")
                .QuerySelectorAll(".displayoffer-middle")
                .Select(node => {
                    var index = node.TextContent.IndexOf(" ");
                    return new CurrencyTradeOffer(offeredCurrency,
                        double.Parse(node.TextContent.Substring(0, index)),
                        requestedCurrency,
                        double.Parse(node.TextContent.Substring(index + 3)));
                });
        }

        private static string GeneratePoeTradeUrl(int offeredCurrencyId, int requestedCurrencyId) {
            //spaces in LeagueName must be replaced with pluses
            return $"{Configuration.Current.CurrencyConfiguration.CurrencyDomain}/search?league={Configuration.Current.LeagueName.Replace(' ', '+')}&online=x&want={offeredCurrencyId}&have={requestedCurrencyId}";
        }
    }
}
