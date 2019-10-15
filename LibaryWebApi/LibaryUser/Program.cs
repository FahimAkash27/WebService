using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace LibaryUser
{
    class Program
    {


        static void Main(string[] args)
        {

            var services = ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<MainMenu>().OpeningScreen();

        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services
                   .AddTransient<IPostToWebservice, PostToWebservice>()
                   .AddTransient<IStudentInformation, StudentInformation>()
                   .AddTransient<IMainMenu, MainMenu>()
                   .AddTransient<IBookInformation, BookInformation>()
                   .AddTransient<IIssueBook, IssueBook>()
                   .AddTransient<IPutToWebservice, PutToWebservice>()
                   .AddTransient<IGetFromWebservice, GetFromWebservice>()
                   .AddTransient<IFineAmount, FineAmount>();

            // IMPORTANT! Register our application entry point
            services.AddTransient<MainMenu>();

            return services;
        }


        public static void Approch1()
        {
            var webRequest = new WebClient();
            webRequest.BaseAddress = "https://localhost:44327";
            var result = webRequest.DownloadString("/api/values/get");
        }

        public static void Approch2()
        {
            const string url = "https://localhost:44327/api/fine/GetFineAmount";

            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using(var response = request.GetResponse())
            {
                using(var streamItem = response.GetResponseStream())
                {
                    using(var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        Console.WriteLine(result);

                        dynamic item = JsonConvert.DeserializeObject(result);
                        Console.WriteLine($"item 1: {item[0]}");
                        Console.WriteLine($"item 2: {item[1]}");
                    }
                }
            }
        }
    }
}
