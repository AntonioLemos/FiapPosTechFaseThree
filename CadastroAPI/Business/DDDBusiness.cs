using CadastroAPI.Business.Interface;
using CadastroAPI.Repository.Interface;
using CadastroAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace CadastroAPI.Business
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
