using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Entities.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class AnswerMapping : MappingBase<AnswerEntity>
    {
        public AnswerMapping() : base("answers")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder.Property(x => x.FormModelId)
                .IsRequired()
                .HasColumnName("form_model_id");

            builder.HasOne(x => x.FormModel)
                .WithMany(relationshipTable => relationshipTable.Answers)
                .HasForeignKey(principalTable => principalTable.FormModelId);
        }
    }
}
