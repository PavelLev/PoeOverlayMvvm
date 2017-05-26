using Newtonsoft.Json;
using PoeOverlayMvvm.Utility.MVVM;

namespace PoeOverlayMvvm.Model.Configurations {
    [JsonObject]
    public class IntervalConfiguration: MyObservable {
        private int _value;

        [JsonProperty]
        public int Default { get; }

        [JsonProperty]
        public int Minimum { get; }

        [JsonProperty]
        public int Value {
            get => _value;
            set {
                if (value == 0) {
                    value = Default;
                }
                if (value < Minimum) {
                    value = Minimum;
                }
                SetField(ref _value, value);
            }
        }

        [JsonConstructor]
        public IntervalConfiguration(int @default, int minimum, int value) {
            Default = @default;
            Minimum = minimum;
            Value = value;
        }
    }
}
