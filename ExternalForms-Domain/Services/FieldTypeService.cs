using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Commum.Enums;
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
                            Name = GetDataType(x.DataType)
                        }
                    })
                );
        }


        private static string GetDataType(DataTypeEnum dataType) =>
            dataType switch
            {
                DataTypeEnum.TEXT => "Textos",
                DataTypeEnum.NUMERIC => "Números",
                DataTypeEnum.DATETIME => "Datas e horas",
                DataTypeEnum.ARCHIVE => "Arquivos",
                _ => string.Empty
            };
    }
}
