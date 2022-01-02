namespace Mango.Web
{
    public class StaticDetails
    {
        public static string ProductApiBaseUrl { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
