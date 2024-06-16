﻿using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.Archive;
using ExternalForms_Domain.Entities.CustomField;

namespace ExternalForms_Domain.Entities.FormModel
{
    public class FormModelEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ArchiveImageId { get; set; }
        public ArchiveEntity ArchiveImage { get; set; }
        public IEnumerable<CustomFieldEntity> CustomFields { get; set; }
        public IEnumerable<AnswerEntity> Answers { get; set; }

    }
}
