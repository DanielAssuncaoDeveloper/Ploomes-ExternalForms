using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Commum.Utils;
using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.CustomField;
using ExternalForms_Domain.Dtos.FieldType;
using ExternalForms_Domain.Entities.CustomField;
using ExternalForms_Domain.Entities.MultipleSelection;
using ExternalForms_Domain.Exceptions;

namespace ExternalForms_Domain.Services
{
    public class CustomFieldService
    {
        private readonly ICustomFieldRepository _customFieldRepository;
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IFormModelRepository _formModelRepository;

        public CustomFieldService(
                ICustomFieldRepository customFieldRepository, 
                IFieldTypeRepository fieldTypeRepository, 
                IFormModelRepository formModelRepository
            )
        {
            _customFieldRepository = customFieldRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _formModelRepository = formModelRepository;
        }

        public async Task<RegistrationReponseDto> Register(CustomFieldDto customField, int idFormModel)
        {
            var record = new CustomFieldEntity();
            record.FormModelId = idFormModel;

            await Validate(customField, idFormModel);
            FillRecord(customField, record);

            await _customFieldRepository.Register(record);
            await _customFieldRepository.Save();

            return new RegistrationReponseDto()
            {
                Id = record.Id
            };
        }

        public async Task Update(CustomFieldDto customField, int id)
        {
            var record = await _customFieldRepository.GetById(id);
            if (record is null)
                throw new DomainLayerException("Campo customizado não encontrado.");

            await Validate(customField, record.FormModelId);
            FillRecord(customField, record);

            await _customFieldRepository.Save();
        }

        public async Task<ChangeActivationResponseDto> ChangeActivation(int id)
        {
            var record = await _customFieldRepository.GetById(id);
            if (record is null)
                throw new DomainLayerException("Campo customizado não encontrado.");

            record.IsInactive = !record.IsInactive;
            foreach (var select in record.MultipleSelections.ToList())
            {
                select.IsInactive = record.IsInactive;
            };

            await _customFieldRepository.Save();

            return new ChangeActivationResponseDto()
            {
                IsInactive = record.IsInactive
            };
        }

        public async Task<List<CustomFieldQueryDto>> Consult(QueryFiltersBaseDto queryFilters)
        {
            var query = _customFieldRepository.GetQuery();

            if (!queryFilters.ShowInactivated)
                query = query.Where(x => !x.IsInactive);

            return await _customFieldRepository.GetList(query.Select(x =>
                    new CustomFieldQueryDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        IsRequired = x.IsRequired,
                        LastUpdate = x.UpdatedAt ?? x.CreatedAt,
                        FieldType = new FieldTypeQueryDto()
                        {
                            Id = x.FieldType.Id,
                            Name = x.FieldType.Name,
                            DataType = new CommumObjectDto()
                            {
                                Id = (int)x.FieldType.DataType,
                                Name = DataTypeUtils.GetDataType(x.FieldType.DataType),
                            }
                        },
                        MultipleSelections = x.MultipleSelections
                            .Select(select => new CommumObjectDto()
                            {
                                Id = select.Id,
                                Name = select.Name,
                            }).ToList()
                    }
                ).Skip(QueryFiltersUtils.PaginationRecords(queryFilters))
                .Take(queryFilters.Limit)
            );
        }


        private async Task Validate(CustomFieldDto customField, int idFormModel)
        {
            if (string.IsNullOrWhiteSpace(customField.Name))
                throw new DomainLayerException("Nome do campo customizado não informado.");

            var formModel = await _formModelRepository.GetById(idFormModel);
            if (formModel is null)
                throw new DomainLayerException("Modelo de formulário não encontrado.");

            var fieldType = await _fieldTypeRepository.GetById(customField.FieldTypeId);
            if (fieldType is null)
                throw new DomainLayerException("Tipo de campo não encontrado.");

            if (fieldType.DataType == DataTypeEnum.MULTIPLE_SELECTION)
            {
                if (customField.MultipleSelections is null || 
                    customField.MultipleSelections.Count == 0)
                    throw new DomainLayerException("Campos de seleção não informados.");
            }
            else
            {
                customField.MultipleSelections = new List<CommumObjectNameDto>();
            }
        }

        private void FillRecord(CustomFieldDto customField, CustomFieldEntity record)
        {
            record.Name = customField.Name;
            record.Description = customField.Description;
            record.FieldTypeId = customField.FieldTypeId;
            record.IsRequired = customField.IsRequired;

            record.MultipleSelections =
                customField.MultipleSelections.Select(x =>
                    new MultipleSelectionEntity()
                    {
                        Name = x.Name
                    }
                ).ToList();
        }
    }
}
