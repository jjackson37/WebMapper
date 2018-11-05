namespace WebMapper
{
    using System;
    using System.Text.RegularExpressions;
    using WebMapper.PageRetrievers;

    public class Program
    {
        private static void Main(string[] args)
        {
            // Get console input
            var pageUrl = Console.ReadLine();

            // Send input to PageRetriever to request web page
            IPageRetriever pageRetriever = new WebClientPageRetriever();
            var htmlCode = pageRetriever.RetrievePage(pageUrl);

            // Remove all new lines and whitespace from the response
            htmlCode = Regex.Replace(htmlCode, @"\s+", string.Empty);
            Console.WriteLine(htmlCode);

            Console.ReadKey();
        }
    }
}
