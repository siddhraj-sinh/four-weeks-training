using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsynAwaitWeatherForcasting
{
    internal class Program
           {
        static string api_key = "b492f83dff3460890467fb9ef070ed64";

        static async Task Main(string[] args)
        {
            var cities = new List<string>
            {
                "Vadodara",
                "Nadiad",
                "Ahmedabad"
            };

            foreach (var c in cities)
            {
                var result = await FetchWeatherDataAsync(c);
                Console.WriteLine($"Temperature in {c}: {result.Main.Temprature}");
                Console.WriteLine($"Humidity in {c}: {result.Main.Humidity}");
                Console.WriteLine();
            }
            Console.ReadLine();
            // Call the method to fetch weather data
            // Display the weather data with city name
        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<WeatherData> FetchWeatherDataAsync(string city)
        {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}";
        HttpClient httpClient = new HttpClient();

        var response = await httpClient.GetAsync(url);
        var data =await response.Content.ReadAsStringAsync();
     
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(data);
            return weatherData;
        }

        public class WeatherData
        {
            [JsonPropertyName("main")]
            public MainData Main { get; set; }


            public class MainData
            {

                [JsonPropertyName("temp")]
                public double Temprature { get; set; }

                [JsonPropertyName("humidity")]
                public int Humidity { get; set; }
            }


        }
    }
}