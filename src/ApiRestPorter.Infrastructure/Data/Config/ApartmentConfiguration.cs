using ApiRestPorter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRestPorter.Infrastructure.Data.Config
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.ApartmentBlock)
                .IsRequired();

            builder.HasMany(a => a.Residents).WithOne(r => r.Apartment);
        }
    }
}
