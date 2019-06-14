using ERP.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings
{
    public class StoredEventsMapping : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("data_cadastro");

            builder.Property(c => c.MessageType)
                .HasColumnName("acao")
                .HasColumnType("varchar(100)");
        }
    }
}