using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.Logic {
    public static class AllCurrenciesObserver {
        private static Timer _updateTimer;

        /// <summary>
        /// 
        /// </summary>
        public static void Load() {
            _updateTimer = new Timer(async state => {
                var begin = DateTime.Now;
                try {
                    await UpdateAllCurrencies();
                }
                catch {
                    //ignore
                }
                MainWindow.TestTimeList.Add((int) (DateTime.Now - begin).TotalMilliseconds);
                //TODO get interval value from configuration
                _updateTimer.Change(5 * 60 * 1000, Timeout.Infinite);
            }, null, 0, Timeout.Infinite);
        }

        public static async Task UpdateAllCurrencies() {
            var chaos = Currency.ByShortName("chaos");
            chaos.OfferedValue = chaos.RequestedValue = 1;

            var currenciesExceptChaos = Configuration.Current.CurrencyConfiguration.AllCurrencies.Except(new[] {chaos}).ToList();

            var requests = new List<Task<IEnumerable<CurrencyTradeOffer>>>(currenciesExceptChaos.Count);

            var offers = new List<Task<IEnumerable<CurrencyTradeOffer>>>(currenciesExceptChaos.Count);

            foreach (var currency in currenciesExceptChaos) {
                requests.Add(CurrencyTradeOffer.GetTradeOffers(chaos, currency));
                offers.Add(CurrencyTradeOffer.GetTradeOffers(currency, chaos));
            }

            Task.Run(async () => {
                while (requests.Count > 0) {
                    var task = await Task.WhenAny(requests);
                    requests.Remove(task);

                    var currencyRequests = task.Result
                        .Take(Configuration.Current.CurrencyConfiguration.ApproximateValuePrecision)
                        .ToList();

                    if (currencyRequests.Count == 0) {
                        continue;
                    }

                    var currency = currencyRequests[0].RequestedCurrency;

                    currency.RequestedValue = currencyRequests.Average(offer => offer.ForOneRequested);
                }
            }).NoWarning();

            while (offers.Count > 0)
            {
                var task = await Task.WhenAny(offers);
                offers.Remove(task);

                var currencyOffers = task.Result
                    .Take(Configuration.Current.CurrencyConfiguration.ApproximateValuePrecision)
                    .ToList();

                if (currencyOffers.Count == 0)
                {
                    continue;
                }

                var currency = currencyOffers[0].OfferedCurrency;

                currency.OfferedValue = currencyOffers.Average(offer => offer.ForOneOffered);
            }
        }
    }
}
