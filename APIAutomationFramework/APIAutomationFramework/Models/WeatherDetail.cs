namespace APIAutomationFramework.Models
{
    public class WeatherDetail
    {
        public Request request { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }
}
