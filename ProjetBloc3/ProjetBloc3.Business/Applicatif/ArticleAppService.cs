using ProjetBloc3.Business.Metier;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Applicatif
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IArticleService _articleService;

        public ArticleAppService(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _articleService.GetAllAsync();
        }

        public async Task CreateAsync(Article article)
        {
            await _articleService.CreateAsync(article);
        }

        public async Task UpdateAsync(Article article)
        {
            await _articleService.UpdateAsync(article);
        }

        public async Task DeleteAsync(Article article)
        {
            await _articleService.DeleteAsync(article);
        }
    }
}
