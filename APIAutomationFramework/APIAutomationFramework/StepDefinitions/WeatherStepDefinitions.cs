using APIAutomationFramework.ServiceObject;
using APIAutomationFramework.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APIAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class WeatherStepDefinitions
    {
        private readonly Context _context;
        private readonly WeatherService _weatherService;

        public WeatherStepDefinitions(Context context)
        {
            _context = context;
            _weatherService = new WeatherService();
        }

        [Given(@"I run the weather api for city : '(.*)'")]
        public void GivenIRunTheWeatherApiForCity(string cityName)
        {
            _context.City = cityName;
            _context.CurrentWeather = _weatherService.GetCurrentWeather(cityName);
        }


        [Then(@"I verify that the api has run successfully")]
        public void ThenIVerifyThatTheApiIsRunSuccessfully()
        {
            Assert.IsTrue(_context.CurrentWeather.IsSuccessful,
                "API call failed to get result for City:" + _context.City);
        }


        [Then(@"I verify the location values returned : '(.*)','(.*)','(.*)'")]
        public void ThenIVerifyTheLocationValuesReturned(string name, string country, string region)
        {
            var detail = _weatherService.GetWeatherDetails(_context.CurrentWeather.Content);

            Assert.AreEqual(name, detail.location.name);
            Assert.AreEqual(country, detail.location.country);
            Assert.AreEqual(region, detail.location.region);
        }
    }
}