namespace ExternalForms_Domain.Dtos.FormModel
{
    public class FormModelQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInactive { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
