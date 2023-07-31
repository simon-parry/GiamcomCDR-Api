namespace GiacomCDR_Api.DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly GiacomDbContext GiacomDbContext;

        public Repository(GiacomDbContext customDbContext) => GiacomDbContext = customDbContext;

        IEnumerable<TEntity> IRepository<TEntity>.GetAll() => GiacomDbContext.Set<TEntity>();

        public async Task<TEntity> GetByIdAsync(Guid id) => await GiacomDbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await GiacomDbContext.AddAsync(entity);
            await GiacomDbContext.SaveChangesAsync();

            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            GiacomDbContext.AddRange(entity);
            GiacomDbContext.SaveChanges();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            GiacomDbContext.Update(entity);
            await GiacomDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var itemToRemove = await GiacomDbContext.Set<TEntity>().FindAsync(id);
            GiacomDbContext.Remove(itemToRemove);
            await GiacomDbContext.SaveChangesAsync();
            return true;
        }
    }
}
