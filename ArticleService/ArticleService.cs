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

    public PagedArticleResult SearchArticles(string searchTerm, int page = 1, int pageSize = 10)
    {
        IEnumerable<Article> query = _contentQuery.ContentAtRoot()
            .SelectMany(x => x.DescendantsOrSelf<Article>());

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(x => x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        int totalItems = query.Count();

        var articles = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedArticleResult
        {
            Articles = articles,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
            CurrentPage = page
        };
    }
}
