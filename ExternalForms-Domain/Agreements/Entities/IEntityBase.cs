namespace ExternalForms_Domain.Agreements.Entities
{
    /// <summary>
    /// Interface para a entidade base das tabelas
    /// </summary>
    public interface IEntityBase
    {
        public int Id { get; set; }
        public bool IsInactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
