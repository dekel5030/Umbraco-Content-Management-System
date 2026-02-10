using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyContentSite.ArticleService;

public interface IArticleService
{
    PagedArticleResult SearchArticles(string searchTerm, int page = 1, int pageSize = 10);
}


public sealed record PagedArticleResult
{
    public required IEnumerable<Article> Articles { get; init; }
    public required int TotalItems { get; init; }
    public required int TotalPages { get; init; }
    public required int CurrentPage { get; init; }
}
