using DeleteAPI.ViewModels;


namespace DeleteAPI.Business.Interface
{
    public interface IDDDBusiness
    {
        Task<IEnumerable<DDDViewModel>> GetAllAsync();
    }
}
