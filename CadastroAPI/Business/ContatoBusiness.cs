using CadastroAPI.Business.Interface;
using CadastroAPI.Repository.Interface;
using CadastroAPI.ViewModels;
using Domain.Models;
using Mapster;

namespace CadastroAPI.Business
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

        public async Task<string> PostContato(ContatoViewModel contatoViewModel)
        {
            var resultValidacao = await contatoViewModel.IsValid();
            if (!resultValidacao.IsValid)
            {
                var errors = string.Join("\n", resultValidacao.Errors.Select(e => e.ErrorMessage));
                return errors;
            }

            var ddd = await _dddRepository.GetDDDPorCodigo(contatoViewModel.DDDSelecionado);

            if (ddd == null)
                return "DDD Inválido.";

            var contatoEmail = await _contatoRepository.GetContatoPorEmail(contatoViewModel.Email);

            if (contatoEmail != null)
                return "Email já existe.";

            var contatoTelefone = await _contatoRepository.GetListaContatoPorTelefone(contatoViewModel.Telefone);

            if (contatoTelefone != null && contatoTelefone.Where(x => x.DDDId.Equals(ddd.Id)).Count() > 0)
                return "Telefone já existe.";

            contatoViewModel.DDDId = ddd.Id;
            contatoViewModel.Mensagem = "";
            CONTATO contato = contatoViewModel.Adapt<CONTATO>();
            contato.Id = new Guid();

            await _contatoRepository.AddAsync(contato);

            contatoViewModel.Id = contato.Id;

            return "Contato Adicionado";
        }

    }
}
