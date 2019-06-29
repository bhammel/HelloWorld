using System;
using System.IO;
using HelloWorld.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HelloWorld.App
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Main(string[] args)
        {
            try
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string message = GetMessageFromApi();
                var messageAdapter = MessageAdapter.GetAdapter(Configuration["WriteMode"]);
                messageAdapter.Write(message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static string GetMessageFromApi()
        {
            var client = new RestClient(Configuration["ApiBaseUrl"]);
            var request = new RestRequest("api/v1/messages/11111111-1111-1111-1111-111111111111");
            var response = client.Execute<MessageResponse>(request);
            if (response.ErrorException != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!response.IsSuccessful)
            {
                throw new Exception(response.StatusDescription);
            }

            return response.Data.Content;
        }
    }
}
