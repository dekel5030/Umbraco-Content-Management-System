using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyContentSite.ArticleService;

public class ArticleService : IArticleService
{
    private readonly IPublishedContentQuery _contentQuery;

    public ArticleService(IPublishedContentQuery contentQuery)
    {
        _contentQuery = contentQuery;
    }

    public IEnumerable<Article> SearchArticles(string searchTerm)
    {
        IEnumerable<Article> allArticles = _contentQuery.ContentAtRoot()
            .SelectMany(x => x.DescendantsOrSelf<Article>());

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            allArticles = allArticles.Where(x =>
                x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        return allArticles.ToList();
    }
}
