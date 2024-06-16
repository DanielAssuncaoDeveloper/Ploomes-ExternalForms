using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.FieldType
{
    public class FieldTypeEntity : EntityBase
    {
        public string Name { get; set; }
        public DataTypeEnum DataType { get; set; }

        public IEnumerable<CustomFieldEntity> CustomFields { get; set; }
    }
}
