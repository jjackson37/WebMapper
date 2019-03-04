namespace WebMapper.PageRetrievers
{
    using System;
    using System.Linq;
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
            bool isValid = VerifyPageUrl(ref url);

            if (isValid)
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
        /// Verifies the page URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The validity of the url</returns>
        private bool VerifyPageUrl(ref string url)
        {
            // TODO #2 : Move this once data solution is agreed on
            var tempDomains = new string[] { ".co.uk", ".com", ".me", ".uk" };

            // Check we have a top-level domain
            if (!tempDomains.Any(url.Contains))
            {
                // TODO : Error Handle here.
                return false;
            }

            // If user has not supplied http or https, prepend it
            if (!Regex.IsMatch(url, "^https?://"))
            {
                // TODO #2 : Check health of url and fix it
                url = "http://" + url;
            }

            return true;
        }
    }
}
