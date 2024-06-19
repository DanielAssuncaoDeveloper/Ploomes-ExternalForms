using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FieldType;
using ExternalForms_Domain.Entities.FormModel;
using ExternalForms_Domain.Entities.MultipleSelection;

namespace ExternalForms_Domain.Entities.CustomField
{
    public class CustomFieldEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }

        public int FormModelId { get; set; }
        public int FieldTypeId { get; set; }

        public FormModelEntity FormModel { get; set; }
        public FieldTypeEntity FieldType { get; set; }

        public List<AnswerFieldEntity> AnswerFields { get; set; }
        public List<MultipleSelectionEntity> MultipleSelections { get; set; }
    }
}
