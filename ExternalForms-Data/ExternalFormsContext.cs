using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.Archive;
using ExternalForms_Domain.Entities.CustomField;
using ExternalForms_Domain.Entities.FieldType;
using ExternalForms_Domain.Entities.FormModel;
using Microsoft.EntityFrameworkCore;

namespace ExternalForms_Data
{
    internal class ExternalFormsContext : DbContext
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

        internal ExternalFormsContext(string stringConnection)
        {
            _stringConnection = stringConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_stringConnection);
        }

        internal void ExecuteMigration()
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao executar um script de migração. Ultimo script executado: {Database.GetPendingMigrations().FirstOrDefault()}", ex);
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
                throw new Exception("Não foi possivel acessar o banco de dados. Verifique os dados de conexão.", ex);
            }
        }
    }
}
