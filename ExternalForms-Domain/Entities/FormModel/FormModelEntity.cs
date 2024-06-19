using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.FormModel
{
    public class FormModelEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CustomFieldEntity> CustomFields { get; set; }
        public List<AnswerEntity> Answers { get; set; }

    }
}
