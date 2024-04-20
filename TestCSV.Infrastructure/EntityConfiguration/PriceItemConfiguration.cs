using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCSV.Domain.Models;

namespace TestCSV.Infrastructure.EntityConfiguration
{
    public class PriceItemConfiguration : IEntityTypeConfiguration<PriceItem>
    {
        public void Configure(EntityTypeBuilder<PriceItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Vendor).HasMaxLength(64);
            builder.Property(i => i.Number).HasMaxLength(64);
            builder.Property(i => i.SearchVendor).HasMaxLength(64);
            builder.Property(i => i.SearchNumber).HasMaxLength(64);
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
            builder.Property(i => i.Description).HasMaxLength(512);
        }
    }
}
