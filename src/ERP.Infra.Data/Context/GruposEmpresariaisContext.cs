using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Infra.Data.Mappings.Gerencial;
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
        public DbSet<Usuario> Usuarios { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public GruposEmpresariaisContext(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GrupoEmpresarialMapping());
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new EstabelecimentoMapping());
            modelBuilder.ApplyConfiguration(new CnaeMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(_hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true).Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ERP_CONNECTION_STRING"));
        }
    }
}