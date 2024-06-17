using ExternalForms_Data.Exceptions;
using ExternalForms_Data.Mapping;
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
            catch (Exception)
            {
                throw new DataLayerException("Não foi possivel acessar o banco de dados. Verifique os dados de conexão.");
            }
        }
    }
}
