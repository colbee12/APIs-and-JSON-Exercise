using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var quotes = new Kanye_Ron();
            quotes.GetQuotes();





            var callWeather = new OpenWeatherMap();
            callWeather.GetWeather();






















        }
    }
}
