using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment hostingEnvironment) : base(options)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(_hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ERP_CONNECTION_STRING"));
        }
    }
}
