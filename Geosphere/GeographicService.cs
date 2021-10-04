using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    abstract class GeographicService
    {
        abstract public string Search(in SearchQuery searchQuery, ref IHttpClient httpClient);
    }
}
