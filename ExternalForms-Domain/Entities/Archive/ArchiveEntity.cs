using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FormModel;

namespace ExternalForms_Domain.Entities.Archive
{
    public class ArchiveEntity : EntityBase
    {
        public string Name { get; set; }
        public string Extension { get; set; }

        public IEnumerable<FormModelEntity> FormModels { get; set; }
        public IEnumerable<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
