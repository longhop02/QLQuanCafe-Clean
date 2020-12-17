using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(m => m.IngredientName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.IngredientSupplier)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(m => m.IngredientUnit)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(m => m.IngredientType)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}