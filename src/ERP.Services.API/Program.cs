using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ERP.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSentry(config => { config.IncludeActivityData = true; })
                .UseStartup<Startup>();
    }
}
