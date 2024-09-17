using ProjetBloc3.Business.Commands;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public interface IRoleServiceApp
    {
        Task<List<UserRole>> GetAllRolesAsync();
        Task<UserRole> GetUserRoleAsync();
        Task UpdateRolesAsync(UpdateRoleCommand roleCommand);
        Task<UserRole> CreateNewRole(CreateRoleCommand roleCommand);
    }
}
