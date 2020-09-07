namespace Covid
{
    public interface IEngine
    {
        /// <summary>
        /// Returns the best matching DataEntry based on a query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The best DataEntry with the most matching words</returns>
        DataEntry Match(string query);
    }
}