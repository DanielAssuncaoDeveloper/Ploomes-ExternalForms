using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.CustomField;
using ExternalForms_Domain.Entities.MultipleSelection;

namespace ExternalForms_Domain.Entities.AnswerField
{
    /// <summary>
    /// Tabela de Campos da Resposta para o Modelo de Formulário
    /// </summary>
    public class AnswerFieldEntity : EntityBase
    {
        /// <summary>
        /// Foreing Key com a Resposta
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Foreing Key com o Campo Customizado
        /// </summary>
        public int CustomFieldId { get; set; }

        /// <summary>
        /// Tipo de informação da resposta (Texto, número, opção de seleção ou data-hora).
        /// </summary>
        public DataTypeEnum DataType { get; set; }


        /// <summary>
        /// Campo para armazenar a resposta do tipo texto
        /// </summary>
        public string TextAnswer { get; set; }

        /// <summary>
        /// Campo para armazenar a resposta de tipo numérico
        /// </summary>
        public decimal NumericAnswer { get; set; }

        /// <summary>
        /// Campo para armazenar a resposta em formato de data
        /// </summary>
        public DateTime? DatetimeAnswer { get; set; }

        /// <summary>
        /// Campo para armazenar a reposta como uma opção de seleção
        /// </summary>
        public int? AnswerMultipleSelectionId { get; set; }


        /// <summary>
        /// Objeto de relacionamento com a Resposta
        /// </summary>
        public AnswerEntity Answer { get; set; }

        /// <summary>
        /// Objeto de relacionamento com o Campo Customizado
        /// </summary>
        public CustomFieldEntity CustomField { get; set; }
        
        /// <summary>
        /// Objeto de relacionamento com a Opção de Seleção
        /// </summary>
        public MultipleSelectionEntity MultipleSelection { get; set; }
    }
}
