using ERP.Services.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace ERP.Tests.Integration
{
    public class Environment
    {
        public static TestServer Server;
        public static HttpClient Client;

        public static void CreateServer()
        {
            Server = new TestServer(new WebHostBuilder().UseEnvironment("Test").UseUrls("http://localhost:99899").UseStartup<StartupTests>());
            Client = Server.CreateClient();
        }
    }
}
