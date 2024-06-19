using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories.Commum;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Dtos.Answer;
using ExternalForms_Domain.Dtos.AnswerField;
using ExternalForms_Domain.Dtos.CustomField;
using ExternalForms_Domain.Dtos.FieldType;
using ExternalForms_Domain.Entities.Answers;

namespace ExternalForms_Data.Repositories
{
    public class AnswerRepository : RepositoryBase<AnswerEntity>, IAnswerRepository
    {
        public AnswerRepository(DatabaseConnection connection) : base(connection)
        {
        }
    }
}
