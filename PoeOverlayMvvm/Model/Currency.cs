using System.Linq;
using PoeOverlayMvvm.Logic;

namespace PoeOverlayMvvm.Model {
    public class Currency {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Id { get; set; }
        public double ApproximateValue { get; set; }


        public static implicit operator Currency(string name) {
            return Configuration.Current.CurrencyConfiguration.AllCurrencies.First(currency => currency.Name == name);
        }
    }
}
