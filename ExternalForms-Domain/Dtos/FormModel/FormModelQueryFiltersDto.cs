using ExternalForms_Domain.Dtos.Commum;

namespace ExternalForms_Domain.Dtos.FormModel
{
    public class FormModelQueryFiltersDto : QueryFiltersBaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
