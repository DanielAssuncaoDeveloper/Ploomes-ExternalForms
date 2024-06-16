using ExternalForms_Data.Mapping.Commum;
using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.FieldType;
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
                    Id = 1,
                    Name = "Texto simples",
                    DataType = DataTypeEnum.TEXT,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 2,
                    Name = "Parágrafo",
                    DataType = DataTypeEnum.TEXT,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 3,
                    Name = "Número simples",
                    DataType = DataTypeEnum.NUMERIC,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 4,
                    Name = "Moeda",
                    DataType = DataTypeEnum.NUMERIC,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 5,
                    Name = "Percentual",
                    DataType = DataTypeEnum.NUMERIC,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 6,
                    Name = "Data e hora",
                    DataType = DataTypeEnum.DATETIME,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 7,
                    Name = "Data",
                    DataType = DataTypeEnum.DATETIME,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 8,
                    Name = "Hora",
                    DataType = DataTypeEnum.DATETIME,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 9,
                    Name = "Sim ou Não",
                    DataType = DataTypeEnum.NUMERIC,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 10,
                    Name = "Multiplas seleções",
                    DataType = DataTypeEnum.TEXT,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 11,
                    Name = "Multipla escolha",
                    DataType = DataTypeEnum.TEXT,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
                new FieldTypeEntity()
                {
                    Id = 12,
                    Name = "Arquivo",
                    DataType = DataTypeEnum.ARCHIVE,
                    IsInactive = false,
                    CreatedAt = new DateTime(2024, 06, 16)
                },
            });

        }
    }
}
