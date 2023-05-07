namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = "Vadodara, India";
            // Call the method to fetch weather data
            // Display the weather data with city name
        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<string> FetchWeatherDataAsync(string url)
        {
            // Fetch web page content asynchronously using HttpClient
            throw new NotImplementedException();
        }
    }
}