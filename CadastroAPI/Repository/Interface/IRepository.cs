namespace CadastroAPI.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddListAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
