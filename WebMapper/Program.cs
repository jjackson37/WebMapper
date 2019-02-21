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

            // Get all URL matches from the page
            var urlMatches = Regex.Matches(htmlCode, "href=\"(.*?)\"");

            foreach (Match match in urlMatches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }

            Console.ReadKey();
        }
    }
}
