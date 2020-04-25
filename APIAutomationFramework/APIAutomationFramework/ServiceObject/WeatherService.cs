using APIAutomationFramework.Models;
using APIAutomationFramework.Support;
using Newtonsoft.Json;
using RestSharp;

namespace APIAutomationFramework.ServiceObject
{
    internal class WeatherService
    {

        public IRestResponse GetCurrentWeather(string cityName)
        {
            var currentWeatherEndpoint = GetEndpoint("currentWeatherEndpoint");

            var client = new RestClient(currentWeatherEndpoint);
            var request = new RestRequest(Method.GET);

            AddQueryParameters(request,cityName);
            
            var response = client.Execute(request);
            return response;
        }

        private void AddQueryParameters(RestRequest request,string cityName)
        {
            var environment = TestConfiguration.GetEnvironmentInfo();

            request.AddQueryParameter("access_key", environment["access_key"] );
            request.AddQueryParameter("query", cityName);
        }

        public WeatherDetail GetWeatherDetails(string currentWeatherContent)
        {
            return JsonConvert.DeserializeObject<WeatherDetail>(currentWeatherContent);
        }

        /// <summary>
        /// Get endpoint information from appsettings.json file
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        private static string GetEndpoint(string endpoint)
        {
            var env = TestConfiguration.GetEnvironmentInfo();
            return env[endpoint];
        }
    }
}
