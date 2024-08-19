using CadastroAPI.ViewModels;

namespace CadastroAPI.Business.Interface
{
    public interface IContatoBusiness
    {
        Task<string> PostContato(ContatoViewModel contatoViewModel);
    }
}
