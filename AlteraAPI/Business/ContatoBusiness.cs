using AlteraAPI.Business.Interface;
using AlteraAPI.Repository.Interface;
using AlteraAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace AlteraAPI.Business
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

        public async Task<string> PutContato(ContatoViewModel contatoViewModel)
        {

            var resultValidacao = await contatoViewModel.IsValid();
            if (!resultValidacao.IsValid)
            {
                var errors = string.Join("\n", resultValidacao.Errors.Select(e => e.ErrorMessage));
                return errors;
            }

            var contato = await _contatoRepository.GetByIdAsync(contatoViewModel.Id ?? Guid.Empty);

            if (contato != null)
            {
                var ddd = await _dddRepository.GetDDDPorCodigo(contatoViewModel.DDDSelecionado);

                if (ddd == null)
                    return "DDD Inválido.";

                var contatoEmail = await _contatoRepository.GetContatoPorEmail(contatoViewModel.Email);

                if (contatoEmail != null && contatoEmail.Id != contato.Id)
                    return "Email já existe.";

                var contatoTelefone = await _contatoRepository.GetListaContatoPorTelefone(contatoViewModel.Telefone);

                if (contatoTelefone != null && contatoTelefone.Any(x => x.DDDId.Equals(ddd.Id) && x.Id != contato.Id))
                    return "Telefone já existe.";

                contato.DDDId = ddd.Id;
                contato.Nome = contatoViewModel.Nome;
                contato.Email = contatoViewModel.Email;
                contato.Telefone = contatoViewModel.Telefone;

                ddd.Codigo = contatoViewModel.DDDSelecionado;

                await _dddRepository.UpdateAsync(ddd);
                await _contatoRepository.UpdateAsync(contato);
            }
            else
            {
                return "Contato Não Encontrado";
            }

            return "Contato Editado";
        }

    }
}
