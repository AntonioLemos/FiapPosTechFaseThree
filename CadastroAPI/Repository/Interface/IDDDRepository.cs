using Domain.Models;

namespace CadastroAPI.Repository.Interface
{
    public interface IDDDRepository : IRepository<DDD>
    {
        Task<DDD> GetDDDPorCodigo(int codigo);
    }
}
