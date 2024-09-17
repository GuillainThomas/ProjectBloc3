using Microsoft.EntityFrameworkCore;
using ProjetBloc3.Repository.BlocCube3;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public class UserService : IUserService
    {
        private BlocCubeContext dbContext;

        public UserService(BlocCubeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserAccount?> GetUserAccount(string username)
        {
            return await Task.FromResult(
                dbContext.UserAccounts
                .Include(x => x.UserRole).ThenInclude(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .FirstOrDefault(x => x.UserName == username)
            );
        }

        public async Task<List<UserAccount>?> GetAllUserAccount()
        {
            return await
                dbContext.UserAccounts
                .Include(x => x.UserRole).ThenInclude(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .OrderBy(x => x.UserName)
                .ToListAsync();
        }

        public async Task<UserAccount?> GetUserAccountById(int id)
        {
            return await
                dbContext.UserAccounts
                .Include(x => x.UserRole).ThenInclude(x => x.UserRoleModuleAccesses).ThenInclude(x => x.Module)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task ChangeUserRole(UserAccount user, UserRole newRole)
        {
            user.UserRole = newRole;
            dbContext.SaveChanges();
        }

        public async Task<UserAccount> Add(UserAccount userAccount)
        {
            dbContext.UserAccounts.Add(userAccount);

            await dbContext.SaveChangesAsync();

            return (await GetUserAccountById(userAccount.Id))!;
        }
    }
}
