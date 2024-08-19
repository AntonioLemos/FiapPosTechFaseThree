using ConsultaAPI.Business.Interface;
using ConsultaAPI.Repository.Interface;
using ConsultaAPI.ViewModels;
using Data.Util;
using Domain.Models;
using Mapster;

namespace ConsultaAPI.Business
{
    public class ContatoBusiness : IContatoBusiness
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IDDDRepository _dddRepository;

        public ContatoBusiness(IContatoRepository contatoRepository, IDDDRepository dddRepository)
        {
            _contatoRepository = contatoRepository;
            _dddRepository = dddRepository;
        }

        public async Task<PagedResult<ContatoViewModel>> GetContatosPaginados(int pageNumber, int pageSize, int ddd)
        {
            var contatos = await _contatoRepository.GetContatosPaginados(pageNumber, pageSize, ddd);
            var contatoVMs = contatos.Items.Select(contato =>
            {
                var vm = contato.Adapt<ContatoViewModel>();
                vm.DDDSelecionado = contato.DDD.Codigo;
                vm.Regiao = contato.DDD.Regiao.ToString();

                return vm;
            });

            return new PagedResult<ContatoViewModel>
            {
                CurrentPage = contatos.CurrentPage,
                PageSize = contatos.PageSize,
                TotalCount = contatos.TotalCount,
                Items = contatoVMs
            };
        }

    }
}
