using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.MultipleSelection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class MultipleSelectionMapping : MappingBase<MultipleSelectionEntity>
    {
        public MultipleSelectionMapping() : base("multiple_selections")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<MultipleSelectionEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.CustomFieldId)
                .HasColumnName("custom_field_id")
                .HasColumnType("int");

            builder.HasOne(x => x.CustomField)
                .WithMany(relationshipTable => relationshipTable.MultipleSelections)
                .HasForeignKey(principalTable => principalTable.CustomFieldId);
        }
    }
}
