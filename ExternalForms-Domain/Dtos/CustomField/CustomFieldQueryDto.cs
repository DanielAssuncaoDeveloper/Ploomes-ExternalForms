using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.FieldType;

namespace ExternalForms_Domain.Dtos.CustomField
{
    public class CustomFieldQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public DateTime LastUpdate { get; set; }
        public FieldTypeQueryDto FieldType { get; set; }
        public List<CommumObjectDto> MultipleSelections { get; set; }
    }
}
