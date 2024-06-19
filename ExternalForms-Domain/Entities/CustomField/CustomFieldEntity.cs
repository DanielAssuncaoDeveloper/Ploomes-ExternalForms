using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FieldType;
using ExternalForms_Domain.Entities.FormModel;
using ExternalForms_Domain.Entities.MultipleSelection;

namespace ExternalForms_Domain.Entities.CustomField
{
    /// <summary>
    /// Tabela com os Campos Customizados relacionados ao Modelo de Formulário
    /// </summary>
    public class CustomFieldEntity : EntityBase
    {
        /// <summary>
        /// Nome do Campo Customizado
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição detalhada do Campo Customizado
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Flag para indicar a obrigatoriedade do campo
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Foreing Key com o Modelo de Formulário
        /// </summary>
        public int FormModelId { get; set; }

        /// <summary>
        /// Foreing Key com o Tipo de Campo
        /// </summary>
        public int FieldTypeId { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Modelo de Formulário
        /// </summary>
        public FormModelEntity FormModel { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Tipo de Campo
        /// </summary>
        public FieldTypeEntity FieldType { get; set; }

        /// <summary>
        /// Lista dos Campos de Resposta vinculados ao Campo Customizado
        /// </summary>
        public List<AnswerFieldEntity> AnswerFields { get; set; }

        /// <summary>
        /// Opções de Seleção vinculados ao Campo Customizado
        /// </summary>
        public List<MultipleSelectionEntity> MultipleSelections { get; set; }
    }
}
