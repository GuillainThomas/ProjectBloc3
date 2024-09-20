using Microsoft.EntityFrameworkCore;
using ProjetBloc3.Business.Metier;
using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Applicatif
{
    public class UserInfoAppService : IUserInfoAppService
    {
        public IUserInfoService _infoService { get; set; }

        public UserInfoAppService(IUserInfoService infoService)
        {
            _infoService = infoService;
        }

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            return await _infoService.GetAllAsync();
        }
        public async Task<UserInfo> GetByIdAsync(int id)
        {
            return await _infoService.GetByIdAsync(id);
        }


        public async Task CreateAsync(UserInfo userInfo)
        {
            await _infoService.CreateAsync(userInfo);
        }

        public async Task UpdateAsync(UserInfo userInfo)
        {
            await _infoService.UpdateAsync(userInfo);
        }

        public async Task DeleteAsync(UserInfo userInfo)
        {
            await _infoService.DeleteAsync(userInfo);
        }
    }
}
