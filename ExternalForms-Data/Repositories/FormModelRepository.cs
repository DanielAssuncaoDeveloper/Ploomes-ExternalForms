using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Entities.FormModel;

namespace ExternalForms_Data.Repositories
{
    public class FormModelRepository : RepositoryBase<FormModelEntity>, IFormModelRepository
    {
        public FormModelRepository(DatabaseConnection connection) : base(connection)
        {
        }
    }
}
