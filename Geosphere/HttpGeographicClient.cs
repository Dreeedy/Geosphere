using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    class HttpGeographicClient : IHttpClient
    {
        private static readonly HttpClient _httpClient;
        private static string _ulr;

        static HttpGeographicClient()
        {
            _httpClient = new HttpClient();
        }

        private string UpdateUrl(in SearchQuery searchQuery)
        {
            string url = $"https://nominatim.openstreetmap.org/search?" +
                $"q={searchQuery.GetAddress()}" +
                $"&polygon_threshold={searchQuery.GetPolygonSimplification()}" +
                $"&format=json" +
                $"&polygon_geojson=1";

            return url;
        }

        public string GetContent(in SearchQuery searchQuery)
        {
            _ulr = UpdateUrl(in searchQuery);

            var task = GetContentAsync(_httpClient);
            task.Wait();

            string result = task.Result;

            if (result != "")
            {
                ConsoleHandler.WriteCyan("[2/4] Географический сервис успешно предоставил ответ...");
            }

            return result;
        }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private async Task<string> GetContentAsync(HttpClient client)
        {
            ConsoleHandler.WriteCyan("[1/4] Выполняет запрос к географическому сервису \"nominatim.openstreetmap.org\"... ");

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                HttpResponseMessage response = await client.GetAsync(_ulr);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nОбнаружено исключение!");
                Console.WriteLine("Ошибка :{0} ", e.Message);
                return "";
            }
        }           
    }
}
