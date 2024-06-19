using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.CustomField;
using ExternalForms_Domain.Entities.MultipleSelection;

namespace ExternalForms_Domain.Entities.AnswerField
{
    public class AnswerFieldEntity : EntityBase
    {
        public int AnswerId { get; set; }
        public int CustomFieldId { get; set; }
        public DataTypeEnum DataType { get; set; }

        public string TextAnswer { get; set; }
        public decimal NumericAnswer { get; set; }
        public DateTime? DatetimeAnswer { get; set; }
        public int? AnswerMultipleSelectionId { get; set; }

        public AnswerEntity Answer { get; set; }
        public CustomFieldEntity CustomField { get; set; }
        public MultipleSelectionEntity MultipleSelection { get; set; }
    }
}
