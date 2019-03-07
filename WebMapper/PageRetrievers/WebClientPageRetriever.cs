namespace WebMapper.PageRetrievers
{
    using System;
    using System.Net;
    using WebMapper.Verifiers;

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
            var protocolValidator = new ProtocolVerifier();

            if (protocolValidator.Verify(url))
            {
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
            }

            return htmlCode;
        }

        /// <summary>
        /// Retrieves the file.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="directory">The directory in which to save the file.</param>
        public void RetrieveFile(string url, string directory)
        {
            var protocolValidator = new ProtocolVerifier();

            if (protocolValidator.Verify(url))
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(url, $"{directory}/{url.Substring(url.LastIndexOf('/') + 1)}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}
