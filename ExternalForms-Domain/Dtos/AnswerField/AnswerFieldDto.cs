using ExternalForms_Domain.Commum.Enums;

namespace ExternalForms_Domain.Dtos.AnswerField
{
    public class AnswerFieldDto
    {
        public int CustomFieldId { get; set; }
        public DataTypeEnum DataType { get; set; }
        public string? TextAnswer { get; set; }
        public DateTime? DateTimeAnswer { get; set; }
        public decimal? NumericAnswer { get; set; }
        public List<int>? MultipleSelectionsIdAnswer { get; set; }
    }
}
