using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Структура описывает входные параметры, которые предоставляет Пользователь: адрес, величина упрощения полигона, имя файла.
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

    /// <summary>
    /// Класс Program описывает основную логику программы
    /// </summary>
    class Program
    {
        private static SearchQuery _searchQuery;

        private static IHttpClient _httpClient;
        private static GeographicService _geographicService;

        private static SaveHandler _saveHandler;

        static Program()
        {           
            _httpClient = new HttpGeographicClient();
            _geographicService = new NominatimGeographicService();

            _saveHandler = new JsonSave("polygons_json");
        }

        private static void Main(string[] args)
        {
            StartGetPolygonsProcess();
        }

        private static void StartGetPolygonsProcess()
        {
            bool continueWork = true;
            do
            {
                _searchQuery = ConsoleHandler.GetSearchQuery();

                string data;
                data = _geographicService.Search(in _searchQuery, ref _httpClient);

                _saveHandler.Save(data, _searchQuery.GetFileName());

                ConsoleHandler.WriteYellow("Введите \"/stop\" или нажмите Enter");
                string command = ConsoleHandler.Read();
                if (command == "/stop")
                {
                    continueWork = false;
                }

                Console.Clear();
            }
            while (continueWork);
        }
    }
}
