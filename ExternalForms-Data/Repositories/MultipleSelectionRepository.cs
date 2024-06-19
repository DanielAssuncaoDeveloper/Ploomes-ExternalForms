using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Entities.MultipleSelection;

namespace ExternalForms_Data.Repositories
{
    public class MultipleSelectionRepository : RepositoryBase<MultipleSelectionEntity>, IMultipleSelectionRepository
    {
        public MultipleSelectionRepository(DatabaseConnection connection) : base(connection)
        {
        }
    }
}
