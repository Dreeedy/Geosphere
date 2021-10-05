using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Интерфейс IHttpClient, объявляет общий фукнционал для всех вариантов обращения к стороннему сервису
    /// </summary>
    interface IHttpClient
    {
        private static readonly HttpClient _httpClient;

        static IHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public string GetContent(in SearchQuery searchQuery);
    }
}
