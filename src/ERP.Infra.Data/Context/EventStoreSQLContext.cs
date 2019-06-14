using ERP.Domain.Core.Events;
using ERP.Infra.Data.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }
        
        private readonly IHostingEnvironment _hostingEnviroment;

        public EventStoreSQLContext(IHostingEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventsMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(_hostingEnviroment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{_hostingEnviroment.EnvironmentName}.json", optional: true).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}