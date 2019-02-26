namespace WebMapper.WebAddressFilters
{
    /// <summary>
    /// Web address filter that filters web addresses not from a given domain
    /// </summary>
    internal class DomainWebAddressFilter : IWebAddressFilter
    {
        /// <summary>
        /// Executes the filter.
        /// </summary>
        /// <param name="webAddresses">The web addresses to be filtered.</param>
        /// <returns>Filtered web addresses</returns>
        public string[] ExecuteFilter(string[] webAddresses)
        {
            // TODO : Actually make it filter
            return webAddresses;
        }
    }
}
