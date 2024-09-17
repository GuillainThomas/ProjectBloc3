using Microsoft.EntityFrameworkCore;
using ProjetBloc3.Repository.BlocCube3;
using ProjetBloc3.Repository.BlocCube3.Models;

namespace ProjetBloc3.Business.Metier
{
    public class ArticleService : IArticleService
    {
        public BlocCubeContext _context { get; set; }

        public ArticleService(BlocCubeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Article article)
        {
            _context.Remove(article);
            await _context.SaveChangesAsync();
        }
    }
}
