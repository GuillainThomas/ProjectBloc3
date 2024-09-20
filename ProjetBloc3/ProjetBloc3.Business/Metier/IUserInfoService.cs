using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Metier
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<UserInfo> GetByIdAsync(int id);
        Task CreateAsync(UserInfo userInfo);
        Task UpdateAsync(UserInfo userInfo);
        Task DeleteAsync(UserInfo userInfo);
    }
}
