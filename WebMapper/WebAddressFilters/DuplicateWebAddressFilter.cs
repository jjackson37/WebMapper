using System.Linq;

namespace WebMapper.WebAddressFilters
{
    /// <summary>
    /// Web address filter that filters duplicate web addresses
    /// </summary>
    internal class DuplicateAddressFilter : IWebAddressFilter
    {
        /// <summary>
        /// Executes the filter.
        /// </summary>
        /// <param name="webAddresses">The web addresses to be filtered.</param>
        /// <returns>Filtered web addresses</returns>
        public string[] ExecuteFilter(string[] webAddresses)
        {
            return webAddresses = webAddresses.Distinct().ToArray();
        }
    }
}
