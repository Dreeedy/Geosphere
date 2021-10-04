using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Класс занимается взаимодействием с консолью
    /// </summary>
    static class ConsoleHandler
    {
        public static void WriteWhite(string text)
        {
            if (Console.ForegroundColor == ConsoleColor.White)
            {                
                Console.WriteLine(text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }

        public static void WriteGreen(string text)
        {
            if (Console.ForegroundColor == ConsoleColor.Green)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }

        public static void WriteYellow(string text)
        {
            if (Console.ForegroundColor == ConsoleColor.Yellow)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }

        public static string Read()
        {
            string text = Console.ReadLine();
            return text;
        }

        public static SearchQuery GetSearchQuery()
        {
            string _address;
            string _polygonSimplification;
            string _fileName;

            _address = ConsoleHandler.GetAddress(out _address);

            _polygonSimplification = ConsoleHandler.GetPolygonSimplification(out _polygonSimplification);

            _fileName = ConsoleHandler.GetFileName(out _fileName);

            SearchQuery searchQuery = new SearchQuery(_address, _fileName, _polygonSimplification);
            WriteGreen($"Адрес: {_address}");
            WriteGreen($"Величина упрощения: {_polygonSimplification}");
            WriteGreen($"Имя: {_fileName}");

            return searchQuery;
        }

        static ConsoleHandler()
        {
            Console.Clear();
            ConsoleHandler.WriteGreen("Начало работы программы...");
        }

        private static string GetAddress(out string _address)
        {
            ConsoleHandler.WriteYellow("Адрес: ");
            _address = ConsoleHandler.Read();
            Console.Clear();

            return _address;
        }

        // TODO: реализовать через float
        private static string GetPolygonSimplification(out string _polygonSimplification)
        {
            ConsoleHandler.WriteYellow("Величина упрощения полигона [0,000]: ");

            _polygonSimplification = ConsoleHandler.Read();

            if (_polygonSimplification == "")// если ничего не ввели
            {
                _polygonSimplification = "0.000";
            }
            Console.Clear();                

            return _polygonSimplification;
        }

        private static string GetFileName(out string _fileName)
        {
            ConsoleHandler.WriteYellow("Имя файла: ");
            _fileName = ConsoleHandler.Read();
            Console.Clear();

            return _fileName;
        }
    }
}
