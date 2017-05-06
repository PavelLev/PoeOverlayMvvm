using System.Net.Http;
using System.Threading.Tasks;

namespace PoeOverlayMvvm.Utility {
    public static class MyHttpClient {
        private static readonly HttpClient HttpClientInstance = new HttpClient();
        
        public static Task<string> GetStringAsync(string requestUri) {
            return HttpClientInstance.GetStringAsync(requestUri);
        }
    }
}
