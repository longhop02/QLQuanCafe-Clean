using Domain.Entities.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(m => m.CustomerName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.CustomerAddress)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.CustomerPhoneNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(m => m.CustomerEmail)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}