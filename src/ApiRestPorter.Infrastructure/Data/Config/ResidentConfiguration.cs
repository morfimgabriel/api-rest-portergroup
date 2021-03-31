using ApiRestPorter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiRestPorter.Infrastructure.Data.Config
{
    public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
    {

        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.FullName)
                .IsRequired();

            builder.Property(r => r.Cpf)
                .IsRequired();

            builder.HasOne(r => r.Apartment).WithMany(a => a.Residents).HasForeignKey(r => r.ApartmentId);
        }

    }
}
