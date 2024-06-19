using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FormModel;

namespace ExternalForms_Domain.Entities.Answers
{
    /// <summary>
    /// Tabela de Reposta do Modelo de Formulário
    /// </summary>
    public class AnswerEntity : EntityBase
    {
        /// <summary>
        /// Foreign Key para o Modelo de Formulário
        /// </summary>
        public int FormModelId { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Modelo de Formulário
        /// </summary>
        public FormModelEntity FormModel { get; set; }

        /// <summary>
        /// Objeto de relacionamento com os Campos de Resposta
        /// </summary>
        public List<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
