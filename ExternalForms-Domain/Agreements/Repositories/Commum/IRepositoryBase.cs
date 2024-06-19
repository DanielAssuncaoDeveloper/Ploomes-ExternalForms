namespace ExternalForms_Domain.Agreements.Repositories.Commum
{
    public interface IRepositoryBase<TEntity>
    {
        Task Save();
        Task Register(TEntity record);
        Task<TEntity?> GetById(int id);
        IQueryable<TEntity> GetQuery();
        Task<List<TQuery>> GetList<TQuery>(IQueryable<TQuery> queries);
    }
}
