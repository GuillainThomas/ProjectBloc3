using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier.Security
{
    public interface IUserService
    {
        Task<UserAccount> Add(UserAccount userAccount);
        Task ChangeUserRole(UserAccount user, UserRole newRole);
        Task<List<UserAccount>?> GetAllUserAccount();
        Task<UserAccount?> GetUserAccount(string username);
        Task<UserAccount?> GetUserAccountById(int id);
    }
}
