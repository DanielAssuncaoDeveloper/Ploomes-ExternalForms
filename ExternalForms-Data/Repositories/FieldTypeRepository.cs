using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Entities.FieldType;

namespace ExternalForms_Data.Repositories
{
    public class FieldTypeRepository : RepositoryBase<FieldTypeEntity>, IFieldTypeRepository
    {
        public FieldTypeRepository(DatabaseConnection connection) : base(connection)
        {
        }
    }
}
