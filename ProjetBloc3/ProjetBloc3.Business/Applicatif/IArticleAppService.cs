using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif
{
    public interface IArticleAppService
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(Article article);
    }
}
