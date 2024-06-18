namespace ExternalForms_Domain.Dtos.Commum
{
    public class QueryFiltersBaseDto
    {
        public bool ShowInactivated { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
