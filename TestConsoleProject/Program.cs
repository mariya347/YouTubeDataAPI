using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using YouTubeDataAPI.Standard;
using YouTubeDataAPI.Standard.Models;
using YouTubeDataAPI.Standard.Controllers;
using YouTubeDataAPI.Standard.Utilities;
using YouTubeDataAPI.Standard.Exceptions;

namespace Testing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            YouTubeDataAPIClient client = new YouTubeDataAPIClient.Builder()
                .CustomQueryAuthenticationCredentials("AIzaSyDEMdvvT0jzsJ9_XARKs79qim7csPO2ehA")
                .Build();
            APIController aPIController = client.APIController;

            Console.Write("Enter a search Item: ");
            string searchItem = Console.ReadLine();

            string part = "";
            string q = searchItem;
            TypeEnum? type = TypeEnum.Video;
            VideoDefinitionEnum? videoDefinition = VideoDefinitionEnum.High;
            string key = "AIzaSyDEMdvvT0jzsJ9_XARKs79qim7csPO2ehA";
            int? maxResults = 1;
            OrderEnum? order = OrderEnum.Relevance;

            try
            {
                SearchListResponse result = await aPIController.YoutubeSearchAsync(part, q, type, videoDefinition, key, null, 
                    null, null, null, null, maxResults, order, null);

                //Console.WriteLine(result.Items);

                JArray items = (JArray)result.Items;
                JObject item = (JObject)items[0];
                string videoId = item["id"]["videoId"].ToString();
                string videoUrl = $"https://www.youtube.com/watch?v={videoId}";
                Console.WriteLine($"The first complete Youtube video URL for '{searchItem}' is: {videoUrl}");
                Console.ReadLine();
            }

            catch (ApiException e)
            {
                    if(e.ResponseCode is 400)
                    {
                        Console.WriteLine("We are sorry, your request cannot be completed due to incompatible parameters");
                    }
                    if (e.ResponseCode is 403)
                    {
                        Console.WriteLine("We are sorry, your request is missing a valid key");
                    }
                    if (e.ResponseCode is 404)
                    {
                        Console.WriteLine("We're sorry, the page you're looking for cannot be found. Please check the URL and try again. " +
                            "If you need further assistance, please contact our support team.");
                    }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown Error: {e.Message}");
            }

        }
    }
}