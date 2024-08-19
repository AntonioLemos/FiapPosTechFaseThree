using AlteraAPI.ViewModels;

namespace AlteraAPI.Business.Interface
{
    public interface IContatoBusiness
    {
        Task<string> PutContato(ContatoViewModel contatoViewModel);
    }
}
