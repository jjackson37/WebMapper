namespace WebMapper.WebAddressFilters
{
    /// <summary>
    /// Web address filter that filters web addresses that are not valid web addresses (i.e. just random strings)
    /// </summary>
    internal class InvalidWebAddressFilter : IWebAddressFilter
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
