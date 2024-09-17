using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task CreateAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(Article article);
    }
}
