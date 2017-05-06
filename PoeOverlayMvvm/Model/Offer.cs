using System.Collections.ObjectModel;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model {
    public class Offer : MyObservable {
        private string _name;
        private double _price;
        private string _orb;

        public string Name {
            get => _name;
            set => SetField(ref _name, value);
        }

        public ObservableCollection<string> Properties { get; set; }

        public double Price {
            get => _price;
            set => SetField(ref _price, value);
        }
        
        public string Orb {
            get => _orb;
            set => SetField(ref _orb, value);
        }

        public string Whisper { get; set; }

    }
}