using ProjetBloc3.Core;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Security.Services
{
    public interface IAuthenticationServiceApp
    {
        //public Task<Response<UserAccount>> Authenticate(string username, string password);
        Task<Response<UserAccount>> AuthenticateWithoutAD(string username);
    }
}