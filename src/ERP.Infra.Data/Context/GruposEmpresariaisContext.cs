using ERP.Admin.Domain.GruposEmpresariais;
using ERP.Infra.Data.Mappings.Admin;
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

        private readonly IConfiguration _configuration;

        public GruposEmpresariaisContext(IConfiguration configuration)
        {
            _configuration = configuration;
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
            optionsBuilder.UseSqlServer(_configuration["ERP_CONNECTION_STRING"]);
        }
    }
}