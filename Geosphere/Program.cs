using System;

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

        /// <summary>
        /// Статический конструктор инициализирует базовые части программы при первом обращении
        /// </summary>
        static Program()
        {           
            _httpClient = new HttpGeographicClient();
            _geographicService = new NominatimGeographicService();

            string mainFolderName = "polygons_json";
            _saveHandler = new JsonSave(mainFolderName);
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            StartGetPolygonsProcess();
        }

        /// <summary>
        /// Метод содержит и управляет "основным циклом" программы
        /// </summary>
        private static void StartGetPolygonsProcess()
        {
            bool continueWork = true;
            do
            {
                // Получаем данные от Пользователя
                _searchQuery = ConsoleHandler.GetSearchQuery();

                // Выполняем запрос к георафическому сервису и получаем ответ
                string data;
                data = _geographicService.Search(in _searchQuery, _httpClient);

                // Сохраняем ответ
                _saveHandler.Save(data, _searchQuery.GetFileName());

                // Способ остановки работы программы
                ConsoleHandler.WriteYellow("Введите \"/stop\" или нажмите Enter");
                string commandStop = ConsoleHandler.Read();
                if (commandStop == "/stop")
                {
                    continueWork = false;
                }

                Console.Clear();
            }
            while (continueWork);
        }
    }
}
