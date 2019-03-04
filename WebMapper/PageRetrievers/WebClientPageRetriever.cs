namespace WebMapper.PageRetrievers
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

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

            // If user has not supplied http or https, prepend it
            if (!Regex.IsMatch(url, "https?://"))
            {
                // TODO #3 : Check health of url and fix it
                url = "http://" + url;
            }

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
