namespace WebMapper.PageRetrievers
{
    /// <summary>
    /// Interface for retrieving web pages
    /// </summary>
    public interface IPageRetriever
    {
        /// <summary>
        /// Retrieves the web page.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Web page Html</returns>
        string RetrievePage(string url);
    }
}
