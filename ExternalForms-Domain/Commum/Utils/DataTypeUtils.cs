using ExternalForms_Domain.Commum.Enums;

namespace ExternalForms_Domain.Commum.Utils
{
    public static class DataTypeUtils
    {
        public static string GetDataType(DataTypeEnum dataType) =>
            dataType switch
            {
                DataTypeEnum.TEXT => "Textos",
                DataTypeEnum.NUMERIC => "Números",
                DataTypeEnum.DATETIME => "Datas e horas",
                DataTypeEnum.MULTIPLE_SELECTION => "Multipla seleção",
                _ => string.Empty
            };

    }
}
