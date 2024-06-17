namespace ExternalForms_Data.Database
{
    public class DatabaseConnection
    {
        internal ExternalFormsContext DbContext { get; set; }

        public DatabaseConnection(string stringConnection)
        {
            DbContext = new ExternalFormsContext(stringConnection);

            DbContext.TestDatabaseConnection();
            DbContext.ExecuteMigration();
        }
    }
}
