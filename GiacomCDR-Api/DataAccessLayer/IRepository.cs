namespace GiacomCDR_Api.DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
