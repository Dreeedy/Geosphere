namespace Geosphere
{
    /// <summary>
    /// Класс для взаимодействия с географическим сервисом Nominatim https://nominatim.openstreetmap.org/
    /// </summary>
    class NominatimGeographicService : GeographicService
    {
        /// <summary>
        /// Метод обращается к сервису и возвращает результат
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public override string Search(in SearchQuery searchQuery, IHttpClient httpClient)
        {
            string result;
            result = httpClient.GetContent(in searchQuery);
            return result;
        }
    }
}
