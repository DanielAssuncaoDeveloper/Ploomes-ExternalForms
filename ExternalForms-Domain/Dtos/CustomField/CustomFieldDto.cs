using ExternalForms_Domain.Dtos.Commum;

namespace ExternalForms_Domain.Dtos.CustomField
{
    public class CustomFieldDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int FieldTypeId { get; set; }
        public bool IsRequired { get; set; }
        public List<CommumObjectNameDto>? MultipleSelections { get; set; }
    }
}
