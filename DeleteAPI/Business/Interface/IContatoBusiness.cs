using DeleteAPI.ViewModels;

namespace DeleteAPI.Business.Interface
{
    public interface IContatoBusiness
    {
        Task<string> DeleteContato(ContatoViewModel contatoViewModel);
    }
}
