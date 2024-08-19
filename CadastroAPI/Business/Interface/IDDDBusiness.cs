using CadastroAPI.ViewModels;


namespace CadastroAPI.Business.Interface
{
    public interface IDDDBusiness
    {
        Task<IEnumerable<DDDViewModel>> GetAllAsync();
    }
}
