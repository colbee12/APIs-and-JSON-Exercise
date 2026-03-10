namespace APIsAndJSON;
using Newtonsoft.Json.Linq;
public class OpenWeatherMap
{
    public void GetWeather()
    {
        
      //OpenWeatherMap API 
           
           //grab the appsettings.json file and read the text it contains
           var appsettingsText = File.ReadAllText("appsettings.json");

           //parse the JSON into A object so we can grab the value of 'Key'
           var apiKey = JObject.Parse(appsettingsText)["Key"].ToString();
           
           //Prompt the user for their zip code
           Console.WriteLine("Please enter your Zip Code");
           
           //store the zip code
           var zipCode = Console.ReadLine();
           

           //using the HTTPClient send a git request to the url created above
           var clientThree = new HttpClient();
           
           //build a Url from where the api call comes from
           //Added &units=imperial to weather API URL ,Convert temperature output to Fahrenheit, Improve readability of temperature output
           var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";
           
           var weatherResponseJson = clientThree.GetStringAsync(weatherUrl).Result;

           //Console.WriteLine(weatherResponseJson);
        
           var parsedWeather = JObject.Parse(weatherResponseJson);
           //Add error handling for missing weather data ,Check if 'weather' field exists in API response,Prevent NullReferenceException when API fails,
           //Display user-friendly error message if weather data is missing
           if (parsedWeather["weather"] != null)
           {
               var weatherDescription = parsedWeather["weather"][0]["description"].ToString();
               var temperature = parsedWeather["main"]["temp"].ToString();
               var city = parsedWeather["name"].ToString();

               Console.WriteLine($"City: {city}");
               Console.WriteLine($"Weather: {weatherDescription}");
               Console.WriteLine($"Temperature: {temperature}°F");
           }
           else
           {
               Console.WriteLine("Weather data not returned. Check your API key or zip code.");
           }

    }
         
}
