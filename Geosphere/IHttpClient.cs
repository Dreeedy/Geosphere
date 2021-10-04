using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    interface IHttpClient
    {
        private static readonly HttpClient _httpClient;

        static IHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public void UpdateUrl(in SearchQuery searchQuery);

        public string GetContent();
    }
}
