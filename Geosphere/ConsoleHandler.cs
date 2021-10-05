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
        static ConsoleHandler()
        {
            Console.Clear();
        }

        /// <summary>
        /// Метод выводит в консоль текст белого цвета
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Метод выводит в консоль тект зеленого цвета
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Метод выводит в консоль тект жёлтого цвета
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Метод выводит в консоль тект голубого цвета
        /// </summary>
        /// <param name="text"></param>
        public static void WriteCyan(string text)
        {
            if (Console.ForegroundColor == ConsoleColor.Cyan)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Метод принимает ввод с консоли
        /// </summary>
        /// <returns></returns>
        public static string Read()
        {
            string text = Console.ReadLine();
            return text;
        }

        /// <summary>
        /// Метод принимает данные от Пользователя и формирует структуру SearchQuery
        /// </summary>
        /// <returns></returns>
        public static SearchQuery GetSearchQuery()
        {
            string _address;
            string _polygonSimplification;
            string _fileName;

            _address = ConsoleHandler.GetAddress(out _address);
            _polygonSimplification = ConsoleHandler.GetPolygonSimplification(out _polygonSimplification);
            _fileName = ConsoleHandler.GetFileName(out _fileName);

            SearchQuery searchQuery = new SearchQuery(_address, _fileName, _polygonSimplification);

            WriteSplitter('*', 120);
            WriteWhite($"Вы ввели:");
            WriteGreen($"[");
            WriteGreen($"Адрес: {_address}");
            WriteGreen($"Величина упрощения полигона: {_polygonSimplification}");
            WriteGreen($"Имя файла: {_fileName}");
            WriteGreen($"]");
            WriteSplitter('*', 120);

            return searchQuery;
        }

        /// <summary>
        /// Метод принимает от Пользователя адрес
        /// </summary>
        /// <param name="_address"></param>
        /// <returns></returns>
        private static string GetAddress(out string _address)
        {
            ConsoleHandler.WriteYellow("Введите адрес: ");
            _address = ConsoleHandler.Read();
            Console.Clear();

            return _address;
        }

        /// <summary>
        /// Метод принимает от Пользователя "Величину упрощения полигона" и выполняет проверки
        /// </summary>
        /// <param name="_polygonSimplification"></param>
        /// <returns></returns>
        private static string GetPolygonSimplification(out string _polygonSimplification)
        {
            // TODO: реализовать через float
            ConsoleHandler.WriteYellow("Введите величину упрощения полигона [0.000 - значение по умолчанию]: ");

            _polygonSimplification = ConsoleHandler.Read();

            if (_polygonSimplification == "")// если ничего не ввели
            {
                _polygonSimplification = "0.000";
            }
            Console.Clear();

            return _polygonSimplification;
        }

        /// <summary>
        /// Метод принимает от Пользователя имя файла
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        private static string GetFileName(out string _fileName)
        {
            ConsoleHandler.WriteYellow("Введите имя файла: ");
            _fileName = ConsoleHandler.Read();
            Console.Clear();

            return _fileName;
        }

        /// <summary>
        /// Метод выводит в консоль строку символов
        /// </summary>
        /// <param name="splitterChar"></param>
        /// <param name="lenght"></param>
        public static void WriteSplitter(char splitterChar, int lenght)
        {
            string splitterRow = "";

            for (int i = 0; i < lenght; i++)
            {
                splitterRow += splitterChar;
            }

            ConsoleHandler.WriteWhite(splitterRow);
        }       
    }
}
