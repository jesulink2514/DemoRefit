using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace DemoRefit.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Enter the title:");
                input = Console.ReadLine();

                SearchMovie(input);

                Console.WriteLine("Enter 'X' to exit");

            } while (!string.Equals(input, "x", StringComparison.InvariantCultureIgnoreCase));
        }

        private static void SearchMovie(string title)
        {
            if (string.Equals(title,"x", StringComparison.InvariantCultureIgnoreCase)) return;

            var moviesClient = CreateMoviesClient();

            var r = moviesClient.FindMovies(null,title, null, null,PlotType.full).Result;

            PrintMovie(r);
        }

        private static IMoviesApi CreateMoviesClient()
        {
            var moviesClient = RestService.For<IMoviesApi>("http://www.omdbapi.com",
                new RefitSettings
                {
                    JsonSerializerSettings = new JsonSerializerSettings {Converters = {new StringEnumConverter()}}
                });
            return moviesClient;
        }

        private static  void PrintMovie(Movie r)
        {
            Console.WriteLine($"year: {r.Year}");
            Console.WriteLine(r.Plot);
            Console.WriteLine();
            Console.WriteLine($"Poster: {r.Poster}");
            Console.WriteLine("==============================================");
            Console.WriteLine();
        }
    }
}
