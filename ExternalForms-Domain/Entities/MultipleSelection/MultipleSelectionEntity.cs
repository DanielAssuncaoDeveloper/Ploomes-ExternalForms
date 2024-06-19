using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.MultipleSelection
{
    /// <summary>
    /// Tabela com as Oções de Seleção dos Campos Customizados
    /// </summary>
    public class MultipleSelectionEntity : EntityBase
    {
        /// <summary>
        /// Nome da Opção de Seleção
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Foreing Key com o Campo Customizado
        /// </summary>
        public int CustomFieldId { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o campo customizado
        /// </summary>
        public CustomFieldEntity CustomField { get; set; }

        /// <summary>
        /// Lista dos Campos de Resposta vinculados a Opção de Seleção
        /// </summary>
        public List<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
