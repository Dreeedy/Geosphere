namespace Geosphere
{
    /// <summary>
    /// Абстрактный класс SaveHandler, объявляет общий функционал для возможных реализаций сохранения файла,
    /// что позволит, при необходимости, реализовать разные способы сохранения файла
    /// </summary>
    abstract class SaveHandler
    {
        /// <summary>
        /// Метод сохраняет данные в определенную директорию в определенном формате
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        abstract public void Save(string data, string fileName);
    }
}
