using ExternalForms_Domain.Agreements.Entities;

namespace ExternalForms_Domain.Entities
{
    /// <summary>
    /// Entidade Base abstrata com os campos padrão das demais tabelas
    /// </summary>
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public bool IsInactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
