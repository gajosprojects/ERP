using ERP.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings
{
    public class StoredEventsMapping : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("stored_events");

            builder.HasKey(storedEvent => storedEvent.Id)
                .HasName("pk_stored_event_id");

            builder.Property(storedEvent => storedEvent.Id)
                .HasColumnName("id");

            builder.Property(storedEvent => storedEvent.TransactionId)
                .HasColumnName("transaction_id");

            builder.Property(storedEvent => storedEvent.AggregateId)
                .HasColumnName("aggregate_id");

            builder.Property(storedEvent => storedEvent.Data)
                .HasColumnName("data");

            builder.Property(storedEvent => storedEvent.Timestamp)
                .HasColumnName("data_cadastro");

            builder.Property(storedEvent => storedEvent.User)
                .HasColumnName("usuario")
                .HasColumnType("varchar(100)");

            builder.Property(storedEvent => storedEvent.MessageType)
                .HasColumnName("acao")
                .HasColumnType("varchar(100)");
        }
    }
}