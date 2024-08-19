using AlteraAPI.ViewModels;


namespace AlteraAPI.Business.Interface
{
    public interface IDDDBusiness
    {
        Task<IEnumerable<DDDViewModel>> GetAllAsync();
    }
}
