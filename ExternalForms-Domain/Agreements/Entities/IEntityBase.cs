namespace ExternalForms_Domain.Agreements.Entities
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public bool IsInactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
