
namespace ezBuy.Infrastructure.DAO_Layer.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> FindById(int id); 
        public Task<TEntity> Create(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task<bool> Delete(int id);    
    }
}
