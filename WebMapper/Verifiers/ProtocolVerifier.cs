namespace WebMapper.Verifiers
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Verifier that checks the web protocol is present.
    /// </summary>
    /// <seealso cref="WebMapper.Verifiers.IVerifier" />
    internal class ProtocolVerifier : IVerifier
    {
        public bool Verify(string url)
        {
            return Regex.IsMatch(url, "^https?://");
        }
    }
}
