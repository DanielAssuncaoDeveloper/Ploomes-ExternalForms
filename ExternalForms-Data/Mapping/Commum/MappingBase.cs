using ExternalForms_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalForms_Data.Mapping.Commum
{
    public abstract class MappingBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        private readonly string _tableName;

        protected MappingBase(string tableName)
        {
            _tableName = tableName;
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(_tableName);
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(prop => prop.CreatedAt)
                .IsRequired()
                .HasColumnName ("created_at")
                .HasColumnType("datetime");

            builder.Property(prop => prop.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(prop => prop.IsInactive)
                .HasColumnName("is_inactive")
                .HasColumnType("bit");

            ApplyConfiguration(builder);
            ReplicateData(builder);
        }

        public abstract void ApplyConfiguration(EntityTypeBuilder<TEntity> builder);

        public virtual void ReplicateData(EntityTypeBuilder<TEntity> builder)
        {
            return;
        }
    }
}
