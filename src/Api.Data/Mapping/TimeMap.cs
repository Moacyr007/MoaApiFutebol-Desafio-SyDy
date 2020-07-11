using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    class TimeMap : IEntityTypeConfiguration<TimeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntity> builder)
        {
            builder.ToTable("Time");
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Nome)
                .IsUnique();
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

