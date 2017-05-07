using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Logic {
    public static class CurrenciesObserver {
        private static Timer _updateTimer;


        public static void InitCurrencies() {
            _updateTimer = new Timer(async state => {
                var begin = DateTime.Now;
                await UpdateAllCurrencies();
                MainWindow.TestTimeList.Add((int) (DateTime.Now - begin).TotalMilliseconds);
            }, null, 0, 15 * 60 * 1000);
        }

        public static async Task UpdateAllCurrencies() {
            var chaos = Currency.ByName("chaos");
            chaos.ApproximateValue = 1;
            
            foreach (var currency in Configuration.Current.CurrencyConfiguration.AllCurrencies.Except(new[] { chaos })) {
                var firstOffers = (await CurrencyTradeOffer.GetTradeOffers(chaos, currency))
                    .Take(Configuration.Current.CurrencyConfiguration.ApproximateValuePrecision)
                    .ToList();
                var firstValue = firstOffers.Count == 0 ? 0 : firstOffers.Average(offer => offer.ForOneRequested);

                var secondOffers = (await CurrencyTradeOffer.GetTradeOffers(currency, chaos))
                    .Take(Configuration.Current.CurrencyConfiguration.ApproximateValuePrecision)
                    .ToList();
                var secondValue = secondOffers.Count == 0 ? 0 : secondOffers.Average(offer => offer.ForOneOffered);

                currency.ApproximateValue = (firstValue + secondValue) / 2;
            }
        }
    }
}
