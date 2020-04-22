using RestSharp;

namespace APIAutomationFramework.Support
{
    public class Context
    {
        public IRestResponse CurrentWeather { get; set; }
        public string City { get; set; }
    }
}
