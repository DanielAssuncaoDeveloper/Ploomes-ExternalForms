using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.CustomField;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class CustomFieldMapping : MappingBase<CustomFieldEntity>
    {
        public CustomFieldMapping() : base("custom_fields")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<CustomFieldEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.IsRequired)
                .HasColumnName("is_required")
                .HasColumnType("bit");

            builder.Property(x => x.FormModelId)
                .IsRequired()
                .HasColumnName("form_model_id")
                .HasColumnType("int");

            builder.Property(x => x.FieldTypeId)
                .IsRequired()
                .HasColumnName("field_type_id")
                .HasColumnType("int");

            builder.HasOne(x => x.FieldType)
                .WithMany(relationshipTable => relationshipTable.CustomFields)
                .HasForeignKey(principalTable => principalTable.FieldTypeId);

            builder.HasOne(x => x.FormModel)
                .WithMany(relationshipTable => relationshipTable.CustomFields)
                .HasForeignKey(principalTable => principalTable.FormModelId);
        }
    }
}
