using ProjetBloc3.Business.Commands;
using ProjetBloc3.Repository.BlocCube3;
using ProjetBloc3.Repository.BlocCube3.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetBloc3.Business.Metier.Security
{
    public class RoleService : IRoleService
    {
        private BlocCubeContext dbContext;

        public RoleService(BlocCubeContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<UserRole>> GetAllRolesAsync()
        {
            return await dbContext.UserRoles
                .Include(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .ToListAsync();
        }
        public async Task<UserRole> GetUserRoleAsync()
        {
            return await dbContext.UserRoles
                .Include(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .Where(x => x.Id == 2).FirstAsync();
        }

        public async Task<UserRole?> GetRoleByid(int id)
        {
            return await dbContext.UserRoles
                .Include(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(UserRole roleToUpdate)
        {
            dbContext.UserRoles.Update(roleToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<UserRole> Add(UserRole roleToCreate)
        {
            dbContext.UserRoles.Add(roleToCreate);

            await dbContext.SaveChangesAsync();

            return (await GetRoleByid(roleToCreate.Id))!;
        }
    }
}
