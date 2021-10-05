using System;
using System.Globalization;
using System.Linq;

namespace Geosphere
{
    /// <summary>
    /// Класс занимается взаимодействием с консолью
    /// </summary>
    static class ConsoleHandler
    {
        /// <summary>
        /// Статический конструктор очищает консоль при запуске программы
        /// </summary>
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
        /// Метод специализирован для вывода ошибок в консоль
        /// </summary>
        /// <param name="e"></param>
        public static void ShowError(Exception e)
        {
            if (Console.ForegroundColor == ConsoleColor.Red)
            {
                Console.WriteLine("\nОбнаружено исключение!");
                Console.WriteLine("Ошибка :{0} ", e.Message);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nОбнаружено исключение!");
                Console.WriteLine("Ошибка :{0} ", e.Message);
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

            ConsoleHandler.GetAddress(out _address);
            ConsoleHandler.GetPolygonSimplification(out _polygonSimplification);
            ConsoleHandler.GetFileName(out _fileName);

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
        /// Метод принимает от Пользователя адрес и выполняет проверки
        /// </summary>
        /// <param name="_address"></param>
        /// <returns></returns>
        private static void GetAddress(out string _address)
        {
            bool go = false;
            
            do
            {
                try
                {
                    AddressValidation(ref go, out _address);
                }
                catch (Exception e)
                {
                    _address = "";
                    ConsoleHandler.ShowError(e);
                }
            } 
            while (go);      
        }

        /// <summary>
        /// Метод выполняет валидацию адреса
        /// </summary>
        /// <param name="go"></param>
        /// <param name="_address"></param>
        private static void AddressValidation(ref bool go, out string _address)
        {
            go = false;

            ConsoleHandler.WriteYellow("Введите адрес: ");
            _address = ConsoleHandler.Read();

            if (_address.Count() <= 0)// если пользователь ничего не ввел
            {
                go = true;
            }

            Console.Clear();
        }

        /// <summary>
        /// Метод принимает от Пользователя "Величину упрощения полигона" и выполняет проверки
        /// </summary>
        /// <param name="_polygonSimplification"></param>
        /// <returns></returns>
        private static string GetPolygonSimplification(out string _polygonSimplification)
        {
            bool go = false;

            do
            {
                try
                {
                    PolygonSimplificationValidation(ref go, out _polygonSimplification);
                }
                catch (Exception e)
                {

                    _polygonSimplification = "";
                    ConsoleHandler.ShowError(e);
                }
            }
            while (go);      

            return _polygonSimplification;
        }

        /// <summary>
        /// Метод выполняет валидацию величины упрощения полигона
        /// </summary>
        /// <param name="go"></param>
        /// <param name="_polygonSimplification"></param>
        private static void PolygonSimplificationValidation(ref bool go, out string _polygonSimplification)
        {
            go = false;

            ConsoleHandler.WriteYellow("Введите величину упрощения полигона [0.000 - значение по умолчанию]: ");

            _polygonSimplification = ConsoleHandler.Read();

            if (_polygonSimplification == "")// если Пользователь ничего не ввел, установка значения по умолчанию
            {
                string defaultPolygonSimplification = "0.000";
                _polygonSimplification = defaultPolygonSimplification;
            }

            if (_polygonSimplification.Count() > 5)// если символов ввели больше чем "0.000"
            {
                go = true;
            }

            //Конвертация во float, для проверки корректное ли число ввел Пользователь
            float value;
            bool isParse;
            isParse = float.TryParse(_polygonSimplification, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            if (!isParse)
            {
                go = true;
            }

            Console.Clear();
        }

        /// <summary>
        /// Метод принимает от Пользователя имя файла и выполняет проверки
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        private static string GetFileName(out string _fileName)
        {
            bool go = false;

            do
            {
                try
                {
                    FileNameValidation(ref go, out _fileName);
                }
                catch (Exception e)
                {
                    _fileName = "";
                    ConsoleHandler.ShowError(e);
                }
            }
            while (go);

            return _fileName;
        }

        /// <summary>
        /// Метод выполняет валидацию имени файла
        /// </summary>
        /// <param name="go"></param>
        /// <param name="_fileName"></param>
        private static void FileNameValidation(ref bool go, out string _fileName)
        {
            go = false;

            ConsoleHandler.WriteYellow("Введите имя файла: ");
            _fileName = ConsoleHandler.Read();

            if (_fileName.Count() <= 0)// если пользователь ничего не ввел
            {
                go = true;
            }

            Console.Clear();
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
