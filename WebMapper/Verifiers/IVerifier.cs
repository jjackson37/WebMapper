namespace WebMapper.Verifiers
{
    /// <summary>
    /// Interface for verifiying
    /// </summary>
    public interface IVerifier
    {
        /// <summary>
        /// Retrieves the web page.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Web page Html</returns>
        bool Verify(string url);
    }
}
