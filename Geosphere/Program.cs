using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Структура описывает входные параметры, которые предоставляет User: адрес, величина упрощения полигона, имя файла.
    /// </summary>
    struct SearchQuery
    {
        string _address;
        string _polygonSimplification;
        string _fileName;

        public SearchQuery(string address, string fileName, string polygonSimplification = "0.000")
        {
            _address = address;            
            _fileName = fileName;
            _polygonSimplification = polygonSimplification;
        }

        public string GetAddress()
        {
            return _address;
        }        

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetPolygonSimplification()
        {
            return _polygonSimplification;
        }
    }

    class Program
    {
        private static SearchQuery _searchQuery;

        private static IHttpClient _httpClient;
        private static GeographicService _geographicService;

        private static SaveHandler _saveHandler;

        static Program()
        {
            _searchQuery = ConsoleHandler.GetSearchQuery();

            _httpClient = new HttpGeographicClient();
            _geographicService = new NominatimGeographicService();

            _saveHandler = new JsonSave();
        }

        private static void Main(string[] args)
        {
            string searchResults;
            searchResults = _geographicService.Search(in _searchQuery, ref _httpClient);
            ConsoleHandler.WriteYellow(searchResults);

            Console.ReadKey();
        }
    }
}
