using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FormModel;

namespace ExternalForms_Domain.Entities.Answers
{
    public class AnswerEntity : EntityBase
    {
        public int FormModelId { get; set; }

        public FormModelEntity FormModel { get; set; }
        public IEnumerable<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
