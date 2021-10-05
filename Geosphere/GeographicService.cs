using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Абстрактный класс GeographicService, объявляет общий функционал для всех географических сервисов,
    /// что позволит использовать любое количество географических сервисов
    /// </summary>
    abstract class GeographicService
    {
        abstract public string Search(in SearchQuery searchQuery, ref IHttpClient httpClient);
    }
}
