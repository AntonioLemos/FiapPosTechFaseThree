using ConsultaAPI.ViewModels;
using Data.Util;

namespace ConsultaAPI.Business.Interface
{
    public interface IContatoBusiness
    {
        Task<PagedResult<ContatoViewModel>> GetContatosPaginados(int pageNumber, int pageSize, int ddd);
    }
}
