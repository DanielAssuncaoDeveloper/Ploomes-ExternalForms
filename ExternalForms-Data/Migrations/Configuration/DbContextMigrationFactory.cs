using Microsoft.EntityFrameworkCore.Design;

namespace ExternalForms_Data.Migrations.Configuration
{
    public class DbContextMigrationFactory : IDesignTimeDbContextFactory<ExternalFormsContext>
    {
        public ExternalFormsContext CreateDbContext(string[] args) => 
            new ExternalFormsContext("SERVER=database-ploomes-externalforms.database.windows.net;UID=API_EXTERNALFORMS;PWD=svgwQBBeg1TRp_EK&2VuB9AaUk7##17*;DATABASE=db-externalforms");
        
    }
}
