﻿using System;
using Newtonsoft.Json;
using PoeOverlayMvvm.Model;

namespace PoeOverlayMvvm.Utility.JsonConverters {
    public class PriceCurrenciesConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Currency);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
