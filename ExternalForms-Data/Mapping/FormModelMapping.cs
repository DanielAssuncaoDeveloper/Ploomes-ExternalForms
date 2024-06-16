using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.FormModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class FormModelMapping : MappingBase<FormModelEntity>
    {
        public FormModelMapping() : base("form_models")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<FormModelEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .HasDefaultValue(string.Empty);
        
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.ArchiveImageId)
                .HasColumnName("image_archive_id")
                .HasColumnType("int");

            builder.HasOne(x => x.ArchiveImage)
                .WithMany(relationshipTable => relationshipTable.FormModels)
                .HasForeignKey(principalTable => principalTable.ArchiveImageId);
        }
    }
}
