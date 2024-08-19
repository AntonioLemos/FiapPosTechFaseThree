using Domain.Models;

namespace AlteraAPI.Repository.Interface
{
    public interface IDDDRepository : IRepository<DDD>
    {
        Task<DDD> GetDDDPorCodigo(int codigo);
    }
}
