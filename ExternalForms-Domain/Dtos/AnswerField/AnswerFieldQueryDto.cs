using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.CustomField;

namespace ExternalForms_Domain.Dtos.AnswerField
{
    public class AnswerFieldQueryDto
    {
        public CommumObjectDto CustomField { get; set; }
        public CommumObjectDto FieldType { get; set; }

        public string TextAnswer { get; set; }
        public DateTime? DatetimeAnswer { get; set; }
        public decimal NumericAnswer { get; set; }
        public List<CommumObjectDto> MultipleSelectedAnswer { get; set; }
    }
}
