using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.FieldType;
using ExternalForms_Domain.Entities.FieldType.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping
{
    public class FieldTypeMapping : MappingBase<FieldTypeEntity>
    {
        public FieldTypeMapping() : base("field_types")
        {
        }

        public override void ApplyConfiguration(EntityTypeBuilder<FieldTypeEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasDefaultValue(string.Empty)
                .HasMaxLength(80);

            builder.Property(x => x.DataType)
                .HasColumnName("data_type")
                .HasColumnType("int");
        }

        public override void ReplicateData(EntityTypeBuilder<FieldTypeEntity> builder)
        {
            builder.HasData(new FieldTypeEntity[]
            {
                new FieldTypeEntity()
                {
                    Id = (int)FieldTypeEnum.SIMPLE_TEXT,
                    Name = "Texto simples",
                    DataType = DataTypeEnum.TEXT,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = (int)FieldTypeEnum.SIMPLE_NUMBER,
                    Name = "Número simples",
                    DataType = DataTypeEnum.NUMERIC,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = (int)FieldTypeEnum.DATETIME,
                    Name = "Data e hora",
                    DataType = DataTypeEnum.DATETIME,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = (int)FieldTypeEnum.MULTIPLE_SELECT,
                    Name = "Multiplas seleções",
                    DataType = DataTypeEnum.MULTIPLE_SELECTION,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = (int)FieldTypeEnum.MULTIPLE_CHOICE,
                    Name = "Multipla escolha",
                    DataType = DataTypeEnum.MULTIPLE_SELECTION,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                }
            });

        }
    }
}
