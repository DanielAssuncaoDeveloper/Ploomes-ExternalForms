using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.MultipleSelection
{
    public class MultipleSelectionEntity : EntityBase
    {
        public string Name { get; set; }
        public int CustomFieldId { get; set; }

        public CustomFieldEntity CustomField { get; set; }
        public List<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
