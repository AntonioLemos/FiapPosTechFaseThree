using Data.Util;
using Domain.Models;

namespace ConsultaAPI.Repository.Interface
{
    public interface IContatoRepository : IRepository<CONTATO>
    {
        Task<PagedResult<CONTATO>> GetContatosPaginados(int pageNumber, int pageSize, int ddd);
        Task<IEnumerable<CONTATO>> GetListaContatoPorTelefone(string telefone);
        Task<CONTATO> GetContatoPorEmail(string email);
    }
}
