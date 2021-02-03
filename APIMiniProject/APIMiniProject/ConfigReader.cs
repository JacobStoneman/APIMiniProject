using System.Configuration;

namespace APIMiniProject
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string BearerToken = ConfigurationManager.AppSettings["bearer_token"];
    }
}
