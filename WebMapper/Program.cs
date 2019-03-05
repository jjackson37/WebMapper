namespace WebMapper
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.Extensions.Configuration;
    using WebMapper.PageRetrievers;
    using WebMapper.WebAddressFilters;

    public class Program
    {
        /// <summary>
        /// The application settings
        /// </summary>
        internal static ApplicationSettings applicationSettings;

        private static void Main(string[] args)
        {
            Initialise();            

            // TODO : Use something (maybe config?) to decide on IPageRetriever usage and move this into a factory
            IPageRetriever pageRetriever = new WebClientPageRetriever();
            pageRetriever.RetrieveFile(applicationSettings.TldRetrievalUrl, applicationSettings.TldLocalCacheDir);

            var pageUrl = Console.ReadLine();
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

        /// <summary>
        /// Initialises the program dependencies.
        /// </summary>
        private static void Initialise()
        {
            // Initialise App Settings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            var config = builder.Build();
            applicationSettings = config.GetSection("applicationSettings").Get<ApplicationSettings>();
        }
    }
}
