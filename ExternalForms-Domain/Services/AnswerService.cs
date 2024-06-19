using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Commum.Enums;
using ExternalForms_Domain.Commum.Utils;
using ExternalForms_Domain.Dtos.Answer;
using ExternalForms_Domain.Dtos.AnswerField;
using ExternalForms_Domain.Dtos.Commum;
using ExternalForms_Domain.Entities.AnswerField;
using ExternalForms_Domain.Entities.Answers;
using ExternalForms_Domain.Entities.FieldType.Enum;
using ExternalForms_Domain.Exceptions;

namespace ExternalForms_Domain.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerFieldRepository _answerFieldRepository;
        private readonly IFormModelRepository _formModelRepository;
        private readonly ICustomFieldRepository _customFieldRepository;
        private readonly IMultipleSelectionRepository _multipleSelectionRepository;

        public AnswerService(
                IAnswerRepository answerRepository, 
                IAnswerFieldRepository answerFieldRepository, 
                IFormModelRepository formModelRepository, 
                ICustomFieldRepository customFieldRepository, 
                IMultipleSelectionRepository multipleSelectionRepository
            )
        {
            _answerRepository = answerRepository;
            _answerFieldRepository = answerFieldRepository;
            _formModelRepository = formModelRepository;
            _customFieldRepository = customFieldRepository;
            _multipleSelectionRepository = multipleSelectionRepository;
        }

        public async Task<RegistrationReponseDto> Register(AnswerDto answer, int idFormModel)
        {
            var record = new AnswerEntity();
            record.FormModelId = idFormModel;

            await Validate(answer, idFormModel);
            await FillRecord(answer, record);

            await _answerRepository.Register(record);
            await _answerRepository.Save();

            return new RegistrationReponseDto()
            {
                Id = record.Id
            };
        }

        public async Task<List<AnswerQueryDto>> Consult(int idFormModel)
        {
            // Consultando primeiramente as Respostas do Modelo de Formulário
            var answerQueries = await _answerRepository.GetList(
                    _answerRepository.GetQuery()
                        .Where(x => x.FormModelId == idFormModel)
                        .Select(x => 
                            new AnswerQueryDto() 
                            { 
                                Id = x.Id
                            })
                        );

            foreach (var answer in answerQueries)
            {
                // Preenchendo os respectivos Campos de Resposta
                var answerFields = await _answerFieldRepository.GetList(
                            _answerFieldRepository.GetQuery()
                            .Where(x => x.AnswerId == answer.Id)
                        );

               /*
                Como as respostas de Multipla Seleção, são informadas pela tabela de Campo de Resposta,
                para não repetir os registros de forma desnecessária, é preciso realizar o agrupamento pelo Campo Customizado.
                */ 
                answer.AnswerFields =
                    answerFields.GroupBy(x => x.CustomField)
                    .Select(x =>
                        new AnswerFieldQueryDto()
                        {
                            CustomField = new CommumObjectDto()
                            {
                                Id = x.Key.Id,
                                Name = x.Key.Name
                            },
                            FieldType = new CommumObjectDto()
                            {
                                Id = x.Key.FieldType.Id,
                                Name = x.Key.FieldType.Name
                            },
                            DatetimeAnswer = x.Max(x => x.DatetimeAnswer),
                            NumericAnswer = x.Max(x => x.NumericAnswer),
                            TextAnswer = x.Max(x => x.TextAnswer) ?? "",
                            MultipleSelectedAnswer = x.Max(x => x.AnswerMultipleSelectionId).GetValueOrDefault() != 0
                                ? x.Select(y =>
                                    new CommumObjectDto()
                                    {
                                        Id = y.MultipleSelection.Id,
                                        Name = y.MultipleSelection.Name
                                    }).ToList()
                                : new List<CommumObjectDto>()
                        }
                    ).ToList();
            }

            return answerQueries;
        }      

        private async Task Validate(AnswerDto answer, int idFormModel)
        {
            var formModel = await _formModelRepository.GetById(idFormModel);
            if (formModel is null)
                throw new DomainLayerException("Modelo de formulário não encontrado.");

            await ValidateRequiredCustomFields(answer.AnswerFields, idFormModel);

            foreach (var answerField in answer.AnswerFields)
            {
                var customField = await _customFieldRepository.GetById(answerField.CustomFieldId);
                if (customField is null)
                    throw new DomainLayerException("Campo customizado não encontrado.");

                if (customField.FormModelId != formModel.Id)
                    throw new DomainLayerException($"O campo customizado {customField.Name} não é referente ao fomulário {formModel.Name}.");

                if (customField.FieldType.DataType != answerField.DataType)
                    throw new DomainLayerException($"O tipo de dado informado não é o mesmo que o do campo customizado {customField.Name}.");

                if (answerField.MultipleSelectionsIdAnswer?.Count > 1
                    && customField.FieldType.Id != (int)FieldTypeEnum.MULTIPLE_SELECT)
                    throw new DomainLayerException("Somente é possível selecionar mais de uma reposta nos campos de Multiplas Seleções.");
            }
        }

        private async Task ValidateRequiredCustomFields(List<AnswerFieldDto> answerField, int idFormModel)
        {
            var formModel = await _formModelRepository.GetById(idFormModel);

            var customFieldsAnswers = answerField.Select(x => x.CustomFieldId).ToList();
            
            // Consultando os Campos Customizados marcados como *Obrigatórios*
            var requiredCustomFields = await _customFieldRepository.GetList(
                    _customFieldRepository.GetQuery()
                        .Where(x =>
                            x.IsRequired
                            && x.FormModelId == idFormModel
                        )
                    );

            // Verificando se existe algum campo obrigatório que não foi informado
            var fieldNotFill = requiredCustomFields.FirstOrDefault(x => !customFieldsAnswers.Contains(x.Id));
            if (fieldNotFill is not null)
                throw new DomainLayerException($"O campo obrigatório {fieldNotFill.Name} não foi preenchido.");
        }

        private async Task FillRecord(AnswerDto answer, AnswerEntity record)
        {
            record.AnswerFields = new List<AnswerFieldEntity>();

            foreach (var answerField in answer.AnswerFields)
            {
                // Caso o Tipo de Campo seja de Multipla Seleção, faz a inclusão
                // de N Campos de Resposta (Um campo de resposta para cada opção selecionada)
                if (answerField.DataType == DataTypeEnum.MULTIPLE_SELECTION)
                {
                    if (answerField.MultipleSelectionsIdAnswer is null ||
                        answerField.MultipleSelectionsIdAnswer.Count == 0)
                        throw new DomainLayerException($"Resposta referente ao tipo {DataTypeUtils.GetDataType(answerField.DataType)} não informada.");

                    foreach (var selectionId in answerField.MultipleSelectionsIdAnswer)
                    {
                        var multipleSelection = await _multipleSelectionRepository.GetById(selectionId);
                        if (multipleSelection is null)
                            throw new DomainLayerException("Escolha de multipla seleção não encontrada.");
                    }

                    var answersSelections = answerField.MultipleSelectionsIdAnswer.Select(selectionId =>
                        new AnswerFieldEntity()
                        {
                            CustomFieldId = answerField.CustomFieldId,
                            DataType = answerField.DataType,
                            AnswerMultipleSelectionId = selectionId
                        });

                    record.AnswerFields.AddRange(answersSelections);
                }
                else
                {
                    var answerFieldRecord = new AnswerFieldEntity();
                    answerFieldRecord.DataType = answerField.DataType;
                    answerFieldRecord.CustomFieldId = answerField.CustomFieldId;

                    switch (answerField.DataType)
                    {
                        case DataTypeEnum.TEXT:
                            FillTextAnswer(answerFieldRecord, answerField.TextAnswer);
                            break;

                        case DataTypeEnum.NUMERIC:
                            FillNumericAnswer(answerFieldRecord, answerField.NumericAnswer);
                            break;

                        case DataTypeEnum.DATETIME:
                            FillDatetimeAnswer(answerFieldRecord, answerField.DateTimeAnswer);
                            break;

                        default:
                            throw new DomainLayerException("Tipo de dado informado não reconhecido.");
                    }

                    record.AnswerFields.Add(answerFieldRecord);
                }
            }
        }

        private void FillTextAnswer(AnswerFieldEntity answerField, string? textAnswer)
        {
            if (string.IsNullOrWhiteSpace(textAnswer))
                throw new DomainLayerException($"Resposta referente ao tipo {DataTypeUtils.GetDataType(answerField.DataType)} não informada.");

            answerField.TextAnswer = textAnswer;
        }

        private void FillDatetimeAnswer(AnswerFieldEntity answerField, DateTime? datetimeAnswer)
        {
            if (datetimeAnswer is null)
                throw new DomainLayerException($"Resposta referente ao tipo {DataTypeUtils.GetDataType(answerField.DataType)} não informada.");

            answerField.DatetimeAnswer = datetimeAnswer;
        }

        private void FillNumericAnswer(AnswerFieldEntity answerField, decimal? numericAnswer)
        {
            if (numericAnswer is null)
                throw new DomainLayerException($"Resposta referente ao tipo {DataTypeUtils.GetDataType(answerField.DataType)} não informada.");

            answerField.NumericAnswer = numericAnswer.GetValueOrDefault();
        }

    }
}
