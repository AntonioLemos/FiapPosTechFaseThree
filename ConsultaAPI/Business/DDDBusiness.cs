using ConsultaAPI.Business.Interface;
using ConsultaAPI.Repository.Interface;
using ConsultaAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace ConsultaAPI.Business
{
    public class DDDBusiness : IDDDBusiness
    {
        private readonly IRepository<DDD> _dddRepository;

        public DDDBusiness(IRepository<DDD> dddRepository)
        {
            _dddRepository = dddRepository;
        }

        public async Task<IEnumerable<DDDViewModel>> GetAllAsync()
        {
            var lstDDD = await _dddRepository.GetAllAsync();
            IEnumerable<DDDViewModel> viewModels = lstDDD.OrderBy(x=>x.Estado).Adapt<IEnumerable<DDDViewModel>>();
            return viewModels;
        }

    }
}
