using ProjetBloc3.Business.Commands;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public interface IRoleService
    {
        Task<List<UserRole>> GetAllRolesAsync();
        Task<UserRole> GetUserRoleAsync();
        Task<UserRole?> GetRoleByid(int id);
        Task Update(UserRole roleToUpdate);
        Task<UserRole> Add(UserRole roleToCreate);
    }
}
