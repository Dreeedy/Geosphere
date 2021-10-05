using System.Net.Http;
using System.Threading.Tasks;

namespace Geosphere
{
    class HttpGeographicClient : IHttpClient
    {
        private static readonly HttpClient _httpClient;
        private static string _ulr;

        /// <summary>
        /// Статический конструктор обеспечивает единоразовое создание HttpClient при первом обращении
        /// </summary>
        static HttpGeographicClient()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Метод обращается к географическому сервису и возвращает результат
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public string GetContent(in SearchQuery searchQuery)
        {
            _ulr = UpdateUrl(in searchQuery);

            var task = GetContentAsync(_httpClient); // Асинхронный вызов метода
            task.Wait();// Ожидание окончания работы асинхронного метода

            string result = task.Result;

            if (result != "")
            {
                ConsoleHandler.WriteCyan("[2/4] Географический сервис успешно предоставил ответ...");
            }

            return result;
        }

        /// <summary>
        /// Метод обновляет новыми данными url сервиса, к которому проихсодит обрщение
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        private string UpdateUrl(in SearchQuery searchQuery)
        {
            string url = $"https://nominatim.openstreetmap.org/search?" +
                $"q={searchQuery.GetAddress()}" +
                $"&polygon_threshold={searchQuery.GetPolygonSimplification()}" +
                $"&format=json" +
                $"&polygon_geojson=1";

            return url;
        }

        /// <summary>
        /// Метод эмулирует "отпечатки" браузера и выполняет обрщание к географическому сервису
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private async Task<string> GetContentAsync(HttpClient client)
        {
            ConsoleHandler.WriteCyan("[1/4] Выполняет запрос к географическому сервису \"nominatim.openstreetmap.org\"... ");

            try
            {
                // Эмуляция отпечаток браузера
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                // Обращение к географическому сервису и получкние ответа
                HttpResponseMessage response = await client.GetAsync(_ulr);
                response.EnsureSuccessStatusCode();

                // Чтение ответа от сервиса
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                ConsoleHandler.ShowError(e);
                return "";
            }
        }           
    }
}
