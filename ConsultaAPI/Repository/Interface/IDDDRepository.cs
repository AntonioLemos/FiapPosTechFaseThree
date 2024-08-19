using Domain.Models;

namespace ConsultaAPI.Repository.Interface
{
    public interface IDDDRepository : IRepository<DDD>
    {
        Task<DDD> GetDDDPorCodigo(int codigo);
    }
}
