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
        /// Метод принимает данные от Пользователя и формирует структуру SearchQuery
        /// </summary>
        /// <returns></returns>
        public static SearchQuery GetSearchQuery()
        {
            string _address;
            string _polygonSimplification;
            string _fileName;

            _address = ConsoleHandler.GetAddress();
            _polygonSimplification = ConsoleHandler.GetPolygonSimplification();
            _fileName = ConsoleHandler.GetFileName();

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
        /// <returns></returns>
        private static string GetAddress()
        {
            bool go = false;
            string text = "";

            do
            {
                try
                {
                    text = AddressValidation(ref go);
                }
                catch (Exception e)
                {
                    ConsoleHandler.ShowError(e);
                }
            }
            while (go);

            return text;
        }

        /// <summary>
        /// Метод выполняет валидацию адреса
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private static string AddressValidation(ref bool go)
        {
            go = false;
            string text;

            ConsoleHandler.WriteYellow("Введите адрес: ");
            text = ConsoleHandler.Read();

            if (text.Count() <= 0)// если пользователь ничего не ввел
            {
                go = true;
            }
            
            Console.Clear();
            return text;
        }

        /// <summary>
        /// Метод принимает от Пользователя "Величину упрощения полигона" и выполняет проверки
        /// </summary>
        /// <returns></returns>
        private static string GetPolygonSimplification()
        {
            bool go = false;
            string text = "";

            do
            {
                try
                {
                    text = PolygonSimplificationValidation(ref go);
                }
                catch (Exception e)
                {

                    ConsoleHandler.ShowError(e);
                }
            }
            while (go);

            return text;
        }

        /// <summary>
        /// Метод выполняет валидацию величины упрощения полигона
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private static string PolygonSimplificationValidation(ref bool go)
        {
            go = false;
            string text;

            ConsoleHandler.WriteYellow("Введите величину упрощения полигона [0.000 - значение по умолчанию]: ");

            text = ConsoleHandler.Read();

            if (text == "")// если Пользователь ничего не ввел, установка значения по умолчанию
            {
                string defaultPolygonSimplification = "0.000";
                text = defaultPolygonSimplification;
            }

            if (text.Count() > 5)// если символов ввели больше чем "0.000"
            {
                go = true;
            }

            //Конвертация во float, для проверки корректное ли число ввел Пользователь
            float value;
            bool isParse;
            isParse = float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
            if (!isParse)
            {
                go = true;
            }

            Console.Clear();
            return text;
        }

        /// <summary>
        /// Метод принимает от Пользователя имя файла и выполняет проверки
        /// </summary>
        /// <returns></returns>
        private static string GetFileName()
        {
            bool go = false;
            string text = "";

            do
            {
                try
                {
                    text = FileNameValidation(ref go);
                }
                catch (Exception e)
                {
                    ConsoleHandler.ShowError(e);
                }
            }
            while (go);

            return text;
        }

        /// <summary>
        /// Метод выполняет валидацию имени файла
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private static string FileNameValidation(ref bool go)
        {
            go = false;
            string text;

            ConsoleHandler.WriteYellow("Введите имя файла: ");
            text = ConsoleHandler.Read();

            if (text.Count() <= 0)// если пользователь ничего не ввел
            {
                go = true;
            }

            Console.Clear();
            return text;
        }

        #region ConsoleColors
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
        #endregion

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
