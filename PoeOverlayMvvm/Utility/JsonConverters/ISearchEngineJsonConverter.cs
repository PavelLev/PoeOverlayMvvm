using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoeOverlayMvvm.Model;
using PoeOverlayMvvm.Model.SearchEngine;

namespace PoeOverlayMvvm.Utility.JsonConverters
{
    public class ISearchEngineJsonConverter : JsonConverter {
        public override bool CanRead { get; } = true;
        public override bool CanWrite { get; } = false;

        public override bool CanConvert(Type objectType) {
            return typeof(ISearchEngine).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jsonObject = JObject.Load(reader);
            var searchEngine = default(ISearchEngine);


            var searchEngineId = jsonObject["Id"].Value<string>();
            switch (searchEngineId) {
                case "poe.trade": {
                    searchEngine = new PoeTradeSearchEngine();
                    break;
                }
                default: {
                    MessageBox.Show($"Search engine {searchEngineId} is not supported");
                    throw new NotImplementedException();
                }
            }

            serializer.Populate(jsonObject.CreateReader(), searchEngine);

            searchEngine.Search();

            return searchEngine;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
