using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHostingEnvironment _hostingEnviroment;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment hostingEnviroment) : base(options)
        {
            _hostingEnviroment = hostingEnviroment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(_hostingEnviroment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{_hostingEnviroment.EnvironmentName}.json", optional: true).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ERP_CONNECTION_STRING"));
        }
    }
}
