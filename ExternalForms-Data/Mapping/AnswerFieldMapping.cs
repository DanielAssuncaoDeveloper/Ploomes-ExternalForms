using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.AnswerField;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class AnswerFieldMapping : MappingBase<AnswerFieldEntity>
    {
        public AnswerFieldMapping() : base("answer_fields")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<AnswerFieldEntity> builder)
        {
            builder.Property(x => x.AnswerId)
                .HasColumnName("answer_id")
                .HasColumnType("int");

            builder.Property(x => x.CustomFieldId)
                .HasColumnName("custom_field_id")
                .HasColumnType("int");

            builder.Property(x => x.DataType)
                .HasColumnName("data_type")
                .HasColumnType("int");

            builder.Property(x => x.TextAnswer)
                .HasColumnName("text_answer")
                .HasColumnType("text")
                .HasDefaultValue(string.Empty);

            builder.Property(x => x.NumericAnswer)
                .HasColumnName("numeric_answer")
                .HasColumnType("numeric")
                .HasPrecision(18, 2);

            builder.Property(x => x.DatetimeAnswer)
                .HasColumnName("datetime_answer")
                .HasColumnType("datetime");

            builder.Property(x => x.AnswerArchiveId)
                .HasColumnName("answer_archive_id")
                .HasColumnType("int");

            builder.HasOne(x => x.Answer)
                .WithMany(relationshipTable => relationshipTable.AnswerFields)
                .HasForeignKey(principalTable => principalTable.AnswerId);

            builder.HasOne(x => x.CustomField)
                .WithMany(relationshipTable => relationshipTable.AnswerFields)
                .HasForeignKey(principalTable => principalTable.CustomFieldId);

            builder.HasOne(x => x.ArchiveAnswer)
                .WithMany(relationshipTable => relationshipTable.AnswerFields)
                .HasForeignKey(principalTable => principalTable.AnswerArchiveId);
        }
    }
}
