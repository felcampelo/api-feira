using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace fair.tests.Controller
{
    public class BaseControllerTest : IDisposable
    {
        protected readonly HttpClient Client;
        public BaseControllerTest()
        {
            var service = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                );
            Client = service.CreateClient();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected HttpRequestMessage CreateRequestMessage(HttpMethod method, string pathApi, object? json = null)
        {
            var request = new HttpRequestMessage(method, pathApi);
            if (json != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json");
            request.Headers.Add("Authorization", "bearer {token}");
            return request;
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
