using Domain.Models;

namespace DeleteAPI.Repository.Interface
{
    public interface IDDDRepository : IRepository<DDD>
    {
        Task<DDD> GetDDDPorCodigo(int codigo);
    }
}
