using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            //kanye
            // Create an instance of a class "HTTPClient" . This is what will make out api call
            var client = new HttpClient();
            
            //Build an api url from where the api will call from.
            var kanyeUrl = "https://api.kanye.rest";
            
            //using the HTTPClient instance
            //Send a git request to the URL created above. this will give us back a string of Json
            var kanyeResponseJson = client.GetStringAsync(kanyeUrl).Result;
            
            //now we parse the JSON response string into JObject
            //we do this to access certain parts of the JSON
            //in this case we will get the value of the key called "quote" witch will give us the actual quote itself
            // - not the JSON body
            
           //      var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();
            //or
            var kanyeQuote = JObject.Parse(kanyeResponseJson)["quote"].ToString();

           Console.WriteLine(kanyeQuote);
           
           
           
           //Ron
           // Create an instance of a class "HTTPClient" . This is what will make out api call
           var clientTwo = new HttpClient();
           
           //Build an api url from where the api will call from.
           var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
           
           //using the HTTPClient instance
           //Send a git request to the URL created above. this will give us back a string of Json
           var ronResponseJson = client.GetStringAsync(ronUrl).Result;
           
               // we use JArray so that the api returns a JSON array
           var ronQuote = JArray.Parse(ronResponseJson)[0].ToString();
           Console.WriteLine(ronQuote);
           
           
           
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
}
