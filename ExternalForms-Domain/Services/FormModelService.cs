using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Commum.Utils;
using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.FormModel;
using ExternalForms_Domain.Entities.FormModel;
using ExternalForms_Domain.Exceptions;

namespace ExternalForms_Domain.Services
{
    public class FormModelService
    {
        private readonly IFormModelRepository _formModelRepository;

        public FormModelService(IFormModelRepository formModelRepository)
        {
            _formModelRepository = formModelRepository;
        }

        public async Task<RegistrationReponseDto> Register(FormModelDto formModel)
        {
            var record = new FormModelEntity();
            
            Validate(formModel);
            FillRecord(formModel, record);

            await _formModelRepository.Register(record);
            await _formModelRepository.Save();

            return new RegistrationReponseDto()
            {
                Id = record.Id,
            };
        }

        public async Task Update(FormModelDto formModel, int id)
        {
            var record = await _formModelRepository.GetById(id);
            if (record is null)
                throw new DomainLayerException("Modelo de formulário não encontrado.");

            Validate(formModel);
            FillRecord(formModel, record);

            await _formModelRepository.Save();
        }

        public async Task<ChangeActivationResponseDto> ChangeActivation(int id)
        {
            var record = await _formModelRepository.GetById(id);
            if (record is null)
                throw new DomainLayerException("Modelo de formulário não encontrado.");

            record.IsInactive = !record.IsInactive;
            await _formModelRepository.Save();

            return new ChangeActivationResponseDto()
            {
                IsInactive = record.IsInactive
            };
        }

        public async Task<List<FormModelQueryDto>> Consult(FormModelQueryFiltersDto queryFilter)
        {
            var query = _formModelRepository.GetQuery();

            if (queryFilter.Id != 0)
                query = query.Where(x => x.Id == queryFilter.Id);

            if (!string.IsNullOrWhiteSpace(queryFilter.Name))
                query = query.Where(x => x.Name.Contains(queryFilter.Name.Trim()));

            if (!string.IsNullOrWhiteSpace(queryFilter.Description))
                query = query.Where(x => x.Description.Contains(queryFilter.Description.Trim()));

            if (!queryFilter.ShowInactivated)
                query = query.Where(x => !x.IsInactive);

            return await _formModelRepository.GetList(query.Select(x =>
                new FormModelQueryDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsInactive = x.IsInactive,
                    LastUpdate = x.UpdatedAt ?? x.CreatedAt
                }).Skip(QueryFiltersUtils.PaginationRecords(queryFilter))
                .Take(queryFilter.Limit)
            );
        }

        private void Validate(FormModelDto formModel)
        {
            if (string.IsNullOrWhiteSpace(formModel.Name))
                throw new DomainLayerException("Nome do modelo de formulário não informado.");
        }

        private void FillRecord(FormModelDto formModel, FormModelEntity record)
        {
            record.Name = formModel.Name;
            record.Description = formModel.Description;
        }
    }
}
