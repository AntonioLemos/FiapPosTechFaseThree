using AlteraAPI.Business.Interface;
using AlteraAPI.Repository.Interface;
using AlteraAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace AlteraAPI.Business
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
