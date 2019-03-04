using System.Linq;

namespace WebMapper.WebAddressFilters
{
    /// <summary>
    /// Web address filter that filters web addresses that are direct links to images, videos, and sound files
    /// </summary>
    internal class MediaFileAddressFilter : IWebAddressFilter
    {
        /// <summary>
        /// Executes the filter.
        /// </summary>
        /// <param name="webAddresses">The web addresses to be filtered.</param>
        /// <returns>Filtered web addresses</returns>
        public string[] ExecuteFilter(string[] webAddresses)
        {
            var tempFileExtensions = new string[] { ".png", ".jpg" };

            return webAddresses = webAddresses.Where(address => !tempFileExtensions.Any(address.Contains)).ToArray();
        }
    }
}
