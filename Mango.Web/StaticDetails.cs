namespace Mango.Web
{
    public class StaticDetails
    {
        public static string ProductApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
