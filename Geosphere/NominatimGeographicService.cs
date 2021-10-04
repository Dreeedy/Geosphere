using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    class NominatimGeographicService : GeographicService
    {
        public override string Search(in SearchQuery searchQuery, ref IHttpClient httpClient)
        {
            string result;
            httpClient.UpdateUrl(in searchQuery);

            result = httpClient.GetContent();

            return result;
        }
    }
}
