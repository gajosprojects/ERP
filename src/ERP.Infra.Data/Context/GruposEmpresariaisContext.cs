using ERP.Admin.Domain.GruposEmpresariais;
using ERP.Infra.Data.Mappings.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERP.Infra.Data.Context
{
    public class GruposEmpresariaisContext : DbContext
    {
        public DbSet<GrupoEmpresarial> GruposEmpresariais { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Cnae> Cnaes { get; set; }
        private readonly IHostingEnvironment _hostingEnviroment;

        public GruposEmpresariaisContext(IHostingEnvironment hostingEnviroment)
        {
            _hostingEnviroment = hostingEnviroment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GrupoEmpresarialMapping());
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new EstabelecimentoMapping());
            modelBuilder.ApplyConfiguration(new CnaeMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(_hostingEnviroment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{_hostingEnviroment.EnvironmentName}.json", optional: true).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ERP_CONNECTION_STRING"));
        }
    }
}