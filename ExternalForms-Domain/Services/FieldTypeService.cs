using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Commum.Utils;
using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Dtos.FieldType;

namespace ExternalForms_Domain.Services
{
    public class FieldTypeService
    {
        private readonly IFieldTypeRepository _fieldTypeRepository;

        public FieldTypeService(IFieldTypeRepository fieldTypeRepository)
        {
            _fieldTypeRepository = fieldTypeRepository;
        }

        public async Task<List<FieldTypeQueryDto>> Consult()
        {
            var records = _fieldTypeRepository.GetQuery();

            return await _fieldTypeRepository.GetList(
                    records.Select(x => new FieldTypeQueryDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        DataType = new CommumObjectDto()
                        {
                            Id = (int)x.DataType,
                            Name = DataTypeUtils.GetDataType(x.DataType)
                        }
                    })
                );
        }
    }
}
