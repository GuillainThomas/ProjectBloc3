using Microsoft.EntityFrameworkCore;
using ProjetBloc3.Repository.BlocCube;
using ProjetBloc3.Repository.BlocCube.Models;

namespace ProjetBloc3.Business.Metier
{
    public class UserInfoService : IUserInfoService
    {
        public BlocCubeContext _context { get; set; }

        public UserInfoService(BlocCubeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            return await _context.UserInfos.ToListAsync();
        }

        public async Task<UserInfo> GetByIdAsync(int id)
        {
            return await _context.UserInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(UserInfo userInfo)
        {
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserInfo userInfo)
        {
            _context.Update(userInfo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserInfo userInfo)
        {
            _context.Remove(userInfo);
            await _context.SaveChangesAsync();
        }
    }
}
