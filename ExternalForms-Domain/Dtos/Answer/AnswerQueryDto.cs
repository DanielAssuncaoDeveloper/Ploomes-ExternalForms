using ExternalForms_Domain.Dtos.AnswerField;

namespace ExternalForms_Domain.Dtos.Answer
{
    public class AnswerQueryDto
    {
        public int Id { get; set; }
        public List<AnswerFieldQueryDto> AnswerFields { get; set; }

    }
}
