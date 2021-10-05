using System.Net.Http;

namespace Geosphere
{
    /// <summary>
    /// Интерфейс IHttpClient, объявляет общий фукнционал для всех вариантов обращения к стороннему сервису
    /// </summary>
    interface IHttpClient
    {
        private static readonly HttpClient _httpClient;

        /// <summary>
        /// Статический конструктор обеспечивает единоразовое создание HttpClient при первом обращении
        /// </summary>
        static IHttpClient()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Метод обращается к сервису и возвращает ответ
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public string GetContent(in SearchQuery searchQuery);
    }
}
