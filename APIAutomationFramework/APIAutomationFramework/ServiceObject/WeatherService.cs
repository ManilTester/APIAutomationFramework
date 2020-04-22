using APIAutomationFramework.Models;
using Newtonsoft.Json;
using RestSharp;

namespace APIAutomationFramework.ServiceObject
{
    internal class WeatherService
    {
        public IRestResponse GetCurrentWeather(string cityName)
        {
            var client = new RestClient("http://api.weatherstack.com/current");
            var request = new RestRequest(Method.GET);

            request.AddQueryParameter("access_key", "0943f1cace1bb5e09c9723d282c5fcec");
            request.AddQueryParameter("query", cityName);

            var response = client.Execute(request);
            return response;
        }

        public WeatherDetail GetWeatherDetails(string currentWeatherContent)
        {
            return JsonConvert.DeserializeObject<WeatherDetail>(currentWeatherContent);
        }
    }
}
