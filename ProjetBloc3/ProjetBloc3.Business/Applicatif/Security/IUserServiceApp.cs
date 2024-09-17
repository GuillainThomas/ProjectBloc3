using ProjetBloc3.Business.Commands;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public interface IUserServiceApp
    {
        Task<UserAccount> CreateNewUserAccount(CreateUserAccountCommand userAccountCommand);
        Task<List<UserAccount>> GetAllUserAccount();
        Task<UserAccount?> GetUserAccount(string username);
        Task UpdateUsersAsync(UpdateUserAccountCommand userCommand);
    }
}
