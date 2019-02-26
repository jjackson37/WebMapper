namespace WebMapper.PageRetrievers
{
    using System;
    using System.Net;

    /// <summary>
    /// Page retriever class that uses the WebClient class
    /// </summary>
    /// <seealso cref="IPageRetriever" />
    internal class WebClientPageRetriever : IPageRetriever
    {
        /// <summary>
        /// Retrieves the web page.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// Web page Html
        /// </returns>
        public string RetrievePage(string url)
        {
            var htmlCode = string.Empty;

            using (var client = new WebClient())
            {
                try
                {
                    htmlCode = client.DownloadString(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return htmlCode;
        }
    }
}
