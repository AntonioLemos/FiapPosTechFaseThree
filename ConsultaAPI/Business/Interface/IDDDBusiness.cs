using ConsultaAPI.ViewModels;


namespace ConsultaAPI.Business.Interface
{
    public interface IDDDBusiness
    {
        Task<IEnumerable<DDDViewModel>> GetAllAsync();
    }
}
