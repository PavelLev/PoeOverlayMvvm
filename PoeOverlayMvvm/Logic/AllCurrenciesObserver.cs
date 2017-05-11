using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Logic {
    public static class AllCurrenciesObserver {
        private static Timer _updateTimer;


        public static void AutomaticUpdate() {
            _updateTimer = new Timer(async state => {
                var begin = DateTime.Now;
                await UpdateAllCurrencies();
                MainWindow.TestTimeList.Add((int) (DateTime.Now - begin).TotalMilliseconds);
                //TODO get interval value from configuration
                _updateTimer.Change(10 * 1000, Timeout.Infinite);
            }, null, 0, Timeout.Infinite);
        }

        public static async Task UpdateAllCurrencies() {
            var chaos = Currency.ByName("Chaos Orb");
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
