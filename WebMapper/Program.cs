namespace WebMapper
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using WebMapper.PageRetrievers;
    using WebMapper.WebAddressFilters;

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

            var stringUrlMatches = urlMatches.Select(m => m.Groups[1].Value).ToArray();

            // TODO : Do this some nice way (Temp code)
            var duplicateAddressFilter = new DuplicateAddressFilter();
            var mediaFileAddressFilter = new MediaFileAddressFilter();

            stringUrlMatches = duplicateAddressFilter.ExecuteFilter(stringUrlMatches);
            stringUrlMatches = mediaFileAddressFilter.ExecuteFilter(stringUrlMatches);

            // Output (Temp code)
            foreach (string match in stringUrlMatches)
            {
                Console.WriteLine(match);
            }

            Console.ReadKey();
        }
    }
}
