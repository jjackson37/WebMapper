namespace WebMapper.WebAddressFilters
{
    /// <summary>
    /// Interface for web address filters
    /// </summary>
    public interface IWebAddressFilter
    {
        /// <summary>
        /// Executes the filter.
        /// </summary>
        /// <param name="webAddresses">The web addresses to be filtered.</param>
        /// <returns>Filtered web addresses</returns>
        string[] ExecuteFilter(string[] webAddresses);
    }
}
