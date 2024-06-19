using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.FormModel
{
    /// <summary>
    /// Tabela do Modelo de Formulário
    /// </summary>
    public class FormModelEntity : EntityBase
    {
        /// <summary>
        /// Nome do Modelo de Formulário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição detalhada do Modelo de Formulário
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista dos Campos Customizados vinculados ao Modelo de Formulário
        /// </summary>
        public List<CustomFieldEntity> CustomFields { get; set; }

        /// <summary>
        /// Lista das Respostas vinculadas ao Modelo de Formulário
        /// </summary>
        public List<AnswerEntity> Answers { get; set; }

    }
}
