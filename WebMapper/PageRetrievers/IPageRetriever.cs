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

        /// <summary>
        /// Retrieves the file.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="directory">The directory in which to save the file.</param>
        void RetrieveFile(string url, string directory);
    }
}
