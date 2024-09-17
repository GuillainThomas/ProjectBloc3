using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public interface IModuleServiceApp
    {
        Task<List<Module>> GetAllModulesAsync();
    }
}
