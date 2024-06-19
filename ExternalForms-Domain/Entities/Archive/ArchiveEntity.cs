﻿using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.FormModel;

namespace ExternalForms_Domain.Entities.Archive
{
    public class ArchiveEntity : EntityBase
    {
        public string Name { get; set; }
        public string Extension { get; set; }

        public List<FormModelEntity> FormModels { get; set; }
        public List<AnswerFieldEntity> AnswerFields { get; set; }
    }
}
