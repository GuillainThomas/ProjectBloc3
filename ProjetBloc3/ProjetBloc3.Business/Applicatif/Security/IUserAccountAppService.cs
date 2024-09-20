using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Applicatif.Security
{
    public interface IUserAccountAppService
    {
        Task<UserAccount> RegisterUserAsync(UserAccount newUser);
        Task<UserAccount?> VerifyPasswordAsync(string username, string enteredPassword);
    }
}
