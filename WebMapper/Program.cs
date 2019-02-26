namespace WebMapper
{
    using System;
    using System.Text.RegularExpressions;
    using WebMapper.PageRetrievers;

    public class Program
    {
        private static void Main(string[] args)
        {
            var pageUrl = Console.ReadLine();

            // TODO : Use something (maybe config?) to decide on IPageRetriever usage and move this into a factory
            IPageRetriever pageRetriever = new WebClientPageRetriever();
            var htmlCode = pageRetriever.RetrievePage(pageUrl);

            // Get all URL matches from the page
            // TODO : Move this into a class structure and use a factory (maybe config?) so we can find URL matches in different ways
            var urlMatches = Regex.Matches(htmlCode, "href=\"(.*?)\"");

            // TODO : Filter URLs here with IWebAddressFilters

            // Output (Temp code)
            foreach (Match match in urlMatches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }

            Console.ReadKey();
        }
    }
}
