using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.FieldType
{
    /// <summary>
    /// Tabela com os Tipos de Campo
    /// </summary>
    public class FieldTypeEntity : EntityBase
    {
        /// <summary>
        /// Nome do Tipo de Campo
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Tipo de informação que é utilizada pelo Tipo de Campo
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// Lista com os Campos Customizados vinculados ao Tipo de Campo
        /// </summary>
        public List<CustomFieldEntity> CustomFields { get; set; }
    }
}
