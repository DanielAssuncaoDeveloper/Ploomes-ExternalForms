using ExternalForms_Domain.Dtos.Commum;

namespace ExternalForms_Domain.Dtos.FieldType
{
    public class FieldTypeQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CommumObjectDto DataType { get; set; }
    }
}
