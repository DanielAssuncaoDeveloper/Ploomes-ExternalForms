using ExternalForms_Data.Exceptions;
using ExternalForms_Data.Mapping;
using ExternalForms_Domain.Agreements.Entities;
using ExternalForms_Domain.Commum.Utils;
using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.Archive;
using ExternalForms_Domain.Entities.CustomField;
using ExternalForms_Domain.Entities.FieldType;
using ExternalForms_Domain.Entities.FormModel;
using Microsoft.EntityFrameworkCore;

namespace ExternalForms_Data
{
    public class ExternalFormsContext : DbContext
    {
        private readonly string _stringConnection;

        #region Tables

        public DbSet<AnswerEntity> Answer { get; set; }
        public DbSet<AnswerFieldEntity> AnswerField { get; set; }
        public DbSet<ArchiveEntity> Archive { get; set; }
        public DbSet<CustomFieldEntity> CustomField { get; set; }
        public DbSet<FieldTypeEntity> FieldType { get; set; }
        public DbSet<FormModelEntity> FormModel { get; set; }

        #endregion

        public ExternalFormsContext(string stringConnection)
        {
            _stringConnection = stringConnection;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_stringConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnswerMapping).Assembly);
        }

        public override int SaveChanges()
        {
            FillStandardFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            FillStandardFields();
            return base.SaveChangesAsync(cancellationToken);
        }


        internal void ExecuteMigration()
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {
                throw new DataLayerException($"Ocorreu um erro ao executar um script de migração. Ultimo script executado: {Database.GetPendingMigrations().FirstOrDefault()}");
            }
        }

        internal void TestDatabaseConnection()
        {
            try
            {
                Database.OpenConnection();
                Database.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new DataLayerException("Não foi possivel acessar o banco de dados. Verifique os dados de conexão.");
            }
        }


        private void FillStandardFields()
        {
            ChangeTracker.DetectChanges();

            foreach (var entrieTracked in ChangeTracker.Entries())
            {
                var entity = entrieTracked.Entity;
                var table = entity as IEntityBase;

                if (table is null)
                {
                    continue;
                }

                // Percorrendo os campos da tabela para aplicar tratamentos
                table.GetType().GetProperties().ToList().ForEach(p => 
                { 
                    // Tratando campos texto para não serem gravados como nulo 
                    // e removendo espaços em branco no inicio e final da string
                    if (p.PropertyType == typeof(string))
                    {
                        string? stringValue = p.GetValue(table) as string;
                        if (stringValue is null)
                            stringValue = string.Empty;

                        stringValue = stringValue.Trim();
                        p.SetValue(table, stringValue);
                    }
                });

                // Verificando status de alteração da entidade
                // para preencher a data de inclusão/alteração
                if (entrieTracked.State == EntityState.Added)
                {
                    table.CreatedAt = DatetimeUtils.GetDateTime();
                }
                if (entrieTracked.State == EntityState.Modified)
                {
                    table.UpdatedAt = DatetimeUtils.GetDateTime();
                }
            }
        }
    }
}
