using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Entities.CustomField;
using Microsoft.EntityFrameworkCore;

namespace ExternalForms_Data.Repositories
{
    public class CustomFieldRepository : RepositoryBase<CustomFieldEntity>, ICustomFieldRepository
    {
        public CustomFieldRepository(DatabaseConnection connection) : base(connection)
        {
        }

        public override async Task<CustomFieldEntity?> GetById(int id) =>
            await _dbContext.CustomField
                .Include(x => x.MultipleSelections)
                .FirstOrDefaultAsync(x => x.Id == id);

        public override IQueryable<CustomFieldEntity> GetQuery() =>
            _dbContext.CustomField
                .Include(x => x.MultipleSelections)
                .Include(x => x.FieldType)
                .AsNoTracking();
    }
}
