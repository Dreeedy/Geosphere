using System;
using System.IO;

namespace Geosphere
{
    /// <summary>
    /// Класс отвечает за сохранение данных в формате JSON
    /// </summary>
    class JsonSave : SaveHandler
    {
        private static string _baseDirectory;
        private static string _pathToJsonFolder;

        /// <summary>
        /// Конструктор принимает название папки для файлов в формате JSON
        /// </summary>
        /// <param name="folderName"></param>
        public JsonSave(string folderName)
        {
            _baseDirectory = GetBaseDirectory();

            CreateFolder(folderName);
        }        

        /// <summary>
        /// Метод сохраняет данные в базовой папке в формате JSON
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public override void Save(string data, string fileName)
        {
            ConsoleHandler.WriteCyan($"[3/4] Сохранение файла [{fileName}.json]... ");

            string path = _pathToJsonFolder + "/" + fileName + ".json";

            try
            {
                // Создание файла
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                // Запись в файл
                streamWriter.Write(data);

                // Закрытие потоков для работы с файлом
                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                ConsoleHandler.ShowError(e);
            }

            ConsoleHandler.WriteCyan($"[4/4] Файл [{fileName}.json] успешно сохранен.");
            ConsoleHandler.WriteSplitter('*', 120);
        }

        /// <summary>
        /// Метод создает директории в "базовой директории"
        /// </summary>
        /// <param name="folderName"></param>
        private void CreateFolder(string folderName)
        {
            string path = _baseDirectory + folderName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            _pathToJsonFolder = path;
        }

        /// <summary>
        /// Метод возвращает путь до базовой директории
        /// </summary>
        /// <returns></returns>
        private string GetBaseDirectory()
        {
            string path;
            path = AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }
    }
}
