using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class IntervalConfiguration: MyObservable {
        private int _interval;
        
        public int Value {
            get => _interval;
            set => SetField(ref _interval, value);
        }

        [JsonProperty]
        public int Default { get; }

        [JsonProperty]
        public int Minimum { get; }

        [JsonConstructor]
        public IntervalConfiguration(int @default, int minimum) {
            Value = Default = @default;
            Minimum = minimum;
        }
    }
}
