using ExternalForms_Data.Database;
using ExternalForms_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExternalForms_Data.Repositories.Commum
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ExternalFormsContext _dbContext;

        public RepositoryBase(DatabaseConnection connection)
        {
            _dbContext = connection.DbContext;
        }

        public virtual async Task Save() =>
            await _dbContext.SaveChangesAsync();

        public virtual async Task Register(TEntity record) =>
            await _dbContext.Set<TEntity>().AddAsync(record);

        public virtual async Task<TEntity?> GetById(int id) =>
            await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        public virtual IQueryable<TEntity> GetQuery() =>
            _dbContext.Set<TEntity>().AsNoTracking();

        public virtual async Task<List<TQuery>> GetList<TQuery>(IQueryable<TQuery> queries) =>
            await queries.ToListAsync();

    }
}
