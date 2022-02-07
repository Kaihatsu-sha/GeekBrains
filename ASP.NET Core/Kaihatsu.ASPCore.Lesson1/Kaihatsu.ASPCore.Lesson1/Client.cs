using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace Kaihatsu.ASPCore.Lesson1
{
    internal class Client
    {
        private HttpClient _httpClient;
        public Client()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Post> GetPost(string url)
        {
            Console.WriteLine($"Start getting { url}");

            Task<HttpResponseMessage> taskResponce = _httpClient.GetAsync(url);
            HttpResponseMessage responce = await taskResponce;
            
            responce.EnsureSuccessStatusCode();

            LongOperation(url);
            Console.WriteLine($"Complit getting { url}");
            var post = await responce.Content.ReadFromJsonAsync<Post>();

            Console.WriteLine($"Complit transform { url}");
            return post;
        }

        private void LongOperation(string url) 
        {
            Random random = new Random();
            int delayTime = random.Next(1000, 10000);
            Console.WriteLine($"Delay: { delayTime} for {url}");
            Task.Delay(delayTime);
        }
    }
}
