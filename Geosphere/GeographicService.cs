namespace Geosphere
{
    /// <summary>
    /// Абстрактный класс GeographicService, объявляет общий функционал для всех географических сервисов,
    /// что позволит использовать любое количество географических сервисов
    /// </summary>
    abstract class GeographicService
    {
        /// <summary>
        /// Метод выполняет запрос к сервису и возвращает результат
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        abstract public string Search(in SearchQuery searchQuery, IHttpClient httpClient);
    }
}
