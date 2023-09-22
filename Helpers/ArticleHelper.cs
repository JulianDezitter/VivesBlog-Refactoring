using VivesBlog.Models;
using VivesBlog.Services;

namespace Helpers
{
    public class ArticleHelper
    {
        private readonly IVivesBlogDbService _dbService;

        public ArticleHelper(IVivesBlogDbService dbService)
        {
            _dbService = dbService;
        }


        public ArticleModel CreateArticleModel(Article? article = null)
        {
            article ??= new Article();

            var authors = _dbService.GetPeopleOrdered();

            var articleModel = new ArticleModel
            {
                Article = article,
                Authors = authors
            };

            return articleModel;
        }
    }
}