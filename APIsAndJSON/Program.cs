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
            
            //useing the HTTPClient instance
            //Send a git request to the URL created above. this will give us back a string of Json
            var kanyeResponseJson = client.GetStringAsync(kanyeUrl).Result;
            
            //now we parse the JSON response string into JObject
            //we do this to access certain parts of the JSON
            //in this case er will getting the value of the key called "quote" witch will give us the actual quote itself
            // - not the JSON body
            
           //      var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();
            //or
            var kanyeQuote = JObject.Parse(kanyeResponseJson)["quote"].ToString();

           Console.WriteLine(kanyeQuote);
           
           
           
           //Ron
           var clientTwo = new HttpClient();
           var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
           var ronResponseJson = client.GetStringAsync(ronUrl).Result;
               // we use JArray so that the api returns a JSON array
           var ronQuote = JArray.Parse(ronResponseJson)[0].ToString();
           Console.WriteLine(ronQuote);

        }
    }
}
