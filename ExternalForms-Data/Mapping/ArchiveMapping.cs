using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.Archive;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class ArchiveMapping : MappingBase<ArchiveEntity>
    {
        public ArchiveMapping() : base("archives")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<ArchiveEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasDefaultValue(string.Empty)
                .HasMaxLength(100);

            builder.Property(x => x.Extension)
                .IsRequired()
                .HasColumnName("extension")
                .HasColumnType("varchar")
                .HasDefaultValue(string.Empty)
                .HasMaxLength(10);
        }
    }
}
