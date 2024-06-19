using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Entities.AnswerField;
using Microsoft.EntityFrameworkCore;

namespace ExternalForms_Data.Repositories
{
    public class AnswerFieldRepository : RepositoryBase<AnswerFieldEntity>, IAnswerFieldRepository
    {
        public AnswerFieldRepository(DatabaseConnection connection) : base(connection)
        {
        }

        public override IQueryable<AnswerFieldEntity> GetQuery() =>
            _dbContext.AnswerField
                .Include(x => x.CustomField)
                    .ThenInclude(x => x.FieldType)
                .Include(x => x.MultipleSelection)
                .AsNoTracking();

    }
}
