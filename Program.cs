using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args) 
        {
            var client = new HttpClient();
            Console.WriteLine($"Please enter your API Key: ");
            var api_Key = Console.ReadLine();
            while (true) 
            {
                Console.WriteLine();
                Console.WriteLine($"Please enter the city name: ");
                var city_Name= Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_Name}&units=imperial&appid={api_Key}";
            

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if(userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}