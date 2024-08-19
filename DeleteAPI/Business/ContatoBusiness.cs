using DeleteAPI.Business.Interface;
using DeleteAPI.Repository.Interface;
using DeleteAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace DeleteAPI.Business
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

        public async Task<string> DeleteContato(ContatoViewModel contatoViewModel)
        {
            var contato = await _contatoRepository.GetByIdAsync(contatoViewModel.Id ?? Guid.Empty);

            if (contato == null)
                return "Contato Inválido";

            await _contatoRepository.DeleteAsync(contato.Id);

            return "Contato Deletado";
        }

    }
}
